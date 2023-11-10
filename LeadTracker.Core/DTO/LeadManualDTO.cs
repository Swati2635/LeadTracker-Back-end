using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class LeadManualDTO
    {
        [JsonRequired]
        public string? Name { get; set; }

        [JsonRequired]
        public string? MobNo { get; set; }

        [JsonRequired]
        public string? EmailId { get; set; }

        [JsonRequired]
        public string? Requirement { get; set;}

        [JsonRequired]
        public decimal? Budget { get; set; }

        public string? Remark { get; set; }

        [JsonRequired]
        public int AssignedTo { get; set; }

    }
}
