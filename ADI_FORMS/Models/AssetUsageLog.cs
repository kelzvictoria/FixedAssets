using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class AssetUsageLog
    {
        public int Id { get; set; }
        public FixedAsset FixedAsset { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        //public int? Maintenance_To_Date { get; set; }
        //public DateTime? Last_Maintenance_Date { get; set; }
        //public DateTime? MaintenanceDueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Trans_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        //public DateTime EndTime { get; set; }
        public string Destination { get; set; }
        public string StaffIdentification { get; set; }


    }
}