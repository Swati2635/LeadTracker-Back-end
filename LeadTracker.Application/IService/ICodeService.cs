﻿using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface ICodeService
    {
        Task CreateCode(CodeDTO code);

        Task<Code> GetCodeByIdAsync(int id);

        Task<IEnumerable<Code>> GetAllCodeAsync();

        Task UpdateCodeAsync(CodeDTO code);

        Task DeleteCodeAsync(int id);
    }
}
