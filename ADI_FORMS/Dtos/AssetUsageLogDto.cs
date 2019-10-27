using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetUsageLogDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        //public int? Maintenance_To_Date { get; set; }
        //public DateTime? Last_Maintenance_Date { get; set; }
        //public DateTime? MaintenanceDueDate { get; set; }
        public DateTime Trans_Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public string Destination { get; set; }
        public string StaffIdentification { get; set; }
    }
}