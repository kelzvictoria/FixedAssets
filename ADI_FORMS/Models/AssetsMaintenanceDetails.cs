
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class AssetsMaintenanceDetails
    {
        public int Id { get; set; }
        public FixedAsset FixedAsset { get; set; }
        [Display(Name="Asset")]
        public int FixedAssetId { get; set; }
        
        [Display(Name = "Maint. Supervisor")]
        public string MaintenanceSupervisor { get; set; }
        [Display(Name = "Transaction Date")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Maint. Description")]
        public string Maint_Description { get; set; }
        [Display(Name = "GL Debit")]
        public long? GLDebit { get; set; }
        [Display(Name = "GL Credit")]
        public long? GLCredit { get; set; }

    }
}