using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ADI_FORMS.Models
{
    public class FixedAsset
    {
        [Display(Name = "Asset No.")]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        public Branch Branch { get; set; }

        [Display(Name = "Branch")]
        [Required]
        public int BranchId { get; set; }

        public Location Location { get; set; }

        [Display(Name = "Location")]
        [Required]
        public int LocationId { get; set; }

        [Display(Name = "Staff Assigned")]
        public string StaffAssigned { get; set; }

        [Display(Name = "Initial Cost")]
        public decimal? InitialCost { get; set; }

        public AssetStatus AssetStatus { get; set; }

        [Display(Name = "Asset Status")]
        [Required]
        public int AssetStatusId { get; set; }

        [Display(Name = "Serial Number")]
        //[Required]
        public long? SerialNo { get; set; }

        [Display(Name = "Purchases Order No.")]
        public long? PurchasesOrderNo { get; set; }

        public string Model { get; set; }

        [Display(Name = "Purchase Recpt. No.")]
        [Required]
        public long? PurchaseRecptNo { get; set; }

        public Vendor Vendor { get; set; }

        [Display(Name = "Vendor")]
        [Required]
        public int VendorId { get; set; }

        [Display(Name = "Year of Manufac.")]
        [Required]
        [Range(2000, 5055)]
        public int? YearOfManufacture { get; set; }

        [Display(Name = "Purchase Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchasedDate { get; set; }

        [Required]
        [Display(Name = "Asset Acc No.")]
        public long? AssetAccountNo { get; set; }

        [Display(Name = "Engine No.")]
        public long? EngineNo { get; set; }

        [Display(Name = "Classic No.")]
        public long? ClassicNo { get; set; }

        public AssetMaintenanceInterval AssetMaintenanceInterval { get; set; }

        [Display(Name = "Maintenance Interval")]
        [Required]
        public int AssetMaintenanceIntervalId { get; set; }

        
        [Display(Name = "Maintenance Fig.")]
        public int? MaintenanceFigure { get; set; }
        [Display(Name = "Present Value")]
        public decimal? PresentValue { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Registered")]
        public DateTime DateRegistered { get; set; }
        [Display(Name = "Last Valuation Date")]
        public DateTime? LastValuationDate { get; set; }

        public DeprInterval DeprInterval { get; set; }
        [Display(Name = "Depreciation Interval")]
        public int? DeprIntervalId { get; set; }
        [Display(Name = "Life Span")]
        public int? LifeSpan { get; set; }

        public Months Months { get; set; }
        [Display(Name = "Last Depr. Month")]
        public int? MonthsId { get; set; }
        
        [Display(Name = "Last Depr. Year")]
        public DateTime? LastDeprYear { get; set; }
        [Display(Name = "Residual")]
        public decimal? Residual { get; set; }
        [Display(Name = "Annual Depr. Amount")]
        public decimal? AnnualDeprAmount { get; set; }
        [Display(Name = "Depreciation Rate")]
        public decimal? DepreciationRate { get; set; }
        [Display(Name = "Last Depr. Date")]
        public DateTime? LastDeprDate { get; set; }
        [Display(Name = "Last Depr. Amt ")]
        public decimal? LastDeprAmt { get; set; }
        [Display(Name = "Depr. YTD")]
        public decimal? DeprYTD { get; set; }
        [Display(Name = "Depr. To Date")]
        public decimal? DeprToDate { get; set; }
        [Display(Name = "GL Debit Acc.")]
        public int? GLDebitAcc { get; set; }
        [Display(Name = "GL Credit Acc")]
        public int? GLCreditAcc { get; set; }

        public DepreciationMTD DepreciationMTD { get; set; }
        [Display(Name = "Depr. Method")]
        public int? DepreciationMTDId { get; set; }
        [Display(Name = "Depr. Start Date ")]
        public DateTime? DeprCommenced { get; set; }

        [Display(Name = "Depr. End Date")]
        public DateTime? DeprEndDate { get; set; }


        [Display(Name = "Current Year")]
        public DateTime? CurrentYear { get; set; }

        public Company Company { get; set; }
        [Display(Name="Company")]
        public int CompanyId { get; set; }

    }
}