using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class LeadSourceDTO
    {
        public IFormFile Files { get; set; }

        public string? LeadsSource { get; set; }

        public string? LeadSourceProject { get; set; }


    }
    public class UploadXMLFileResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ExcelBulkUploadParameter
    {

        public string? Name { get; set; }

        public string? MobNo { get; set; }

        public string? EmailId { get; set; }

        public string? Requirement { get; set; }

        public decimal? Budget { get; set; }

        public string? Remark { get; set; }



    }
}
