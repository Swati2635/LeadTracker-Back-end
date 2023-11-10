using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LeadTracker.BusinessLayer.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentrepository;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDocumentRepository documentRepository, ILogger<DocumentService> logger)
        {
            _documentrepository= documentRepository;
            _logger= logger;
        }

        public async Task CreateDocument(int userId, int orgId, DocumentDTO document)
        {
            var docs = new List<Document>();
            foreach (var doc in document.Files)
            {
                var outputFile = await WriteFile(doc);
                if (!string.IsNullOrEmpty(outputFile))
                {
                    docs.Add(new Document()
                    {
                        Comment = document.Comment,
                        EnquiryId = document.EnquiryId,
                        Location = outputFile,
                        ModuleType = document.ModuleType,
                        OrgId = orgId,
                        UserId = userId,
                        WorkFlowId = document.WorkFlowId,
                        WorkFlowStepId = document.WorkFlowStepId,
                        TrackerId = document.TrackerId,
                    });
                }
            }
            await _documentrepository.CreateAllAsync(docs).ConfigureAwait(false);
        }


        public async Task InsertStatus(StatusDTO status, int orgId, int userId)
        {
            if (status.Files != null && status.Files.Count > 0)
            {
                var documents = new List<Document>(); 

                foreach (var doc in status.Files)
                {
                    var outputFile = await WriteFile(doc);
                    if (!string.IsNullOrEmpty(outputFile))
                    {
                        
                        var document = new Document
                        {
                            EnquiryId = status.EnquiryId,
                            TrackerId = status.TrackerId,
                            ModuleType = status.ModuleType,
                            Location = outputFile,
                            Comment = status.Comment,
                            WorkFlowId = status.WorkFlowId,
                            WorkFlowStepId = status.CurrentWorkFlowStepId,
                            OrgId = orgId,
                            UserId = userId
                        };

                        documents.Add(document); 
                    }
                }

                
                await _documentrepository.CreateAllAsync(documents).ConfigureAwait(false);
            }

            
            var tracker = new Tracker
            {
                EnquiryId = status.EnquiryId,
                VisitExpectedDate = status.VisitExpectedDate,
                CodeId = status.ModuleType,
                Remark = status.Comment,
                Date = DateTime.UtcNow,
                VisitExpected = null,
                VisitedProjectId = status.VisitedProjectId,
                VisitRemark = null,
                AssignedTo = userId,
                WorkFlowId = status.WorkFlowId,
                WorkFlowStepId = status.NextWorkFlowStepId,
                IsStepCompleted = false,
                OrgId = orgId
            };

            await _documentrepository.CreateTracker(tracker);

            if (status.Files != null)
            {
                foreach (var file in status.Files)
                {
                    await WriteFile(file);
                }
            }
        }

        public async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var outputFile = Path.Combine("Upload\\Files\\" + file.FileName);
                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), outputFile);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return outputFile; 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
