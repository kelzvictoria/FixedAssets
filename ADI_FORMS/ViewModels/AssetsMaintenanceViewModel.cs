using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsMaintenanceViewModel
    {
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<AssetsMaintenanceDetails> AssetsMaintenanceDetails { get; set; }
        public AssetsMaintenanceDetails AssetsMaintenanceDetail { get; set; }
        public int Id { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [Display(Name = "Maint. Supervisor")]
        public string MaintenanceSupervisor { get; set; }
        [Display(Name = "Trans. Date")]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Maint_Description { get; set; }
        [Display(Name = "GL Debit")]
        public long? GLDebit { get; set; }
        [Display(Name = "GL Credit")]
        public long? GLCredit { get; set; }

        public AssetsMaintenanceViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Maintenance Details ";
            }
        }
        public AssetsMaintenanceViewModel(AssetsMaintenanceDetails amd)
        {
            Id = amd.Id;
            MaintenanceSupervisor = amd.MaintenanceSupervisor;
            TransactionDate = amd.TransactionDate;
            Amount = amd.Amount;
            Maint_Description = amd.Maint_Description;
            GLDebit = amd.GLDebit;
            GLCredit = amd.GLCredit;
            FixedAssetId = amd.FixedAssetId;
        }
        
    }


}