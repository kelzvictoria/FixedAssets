using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADI_FORMS.Models;
using System.ComponentModel.DataAnnotations;

namespace ADI_FORMS.ViewModels
{
    public class RegisterAssetViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<AssetStatus> AssetStatus { get; set; }
        public IEnumerable<AssetMaintenanceInterval> AssetMaintenanceIntervals { get; set; }
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<DepreciationMTD> DepreciationMTDs { get; set; }
        public IEnumerable<DeprInterval> DeprIntervals { get; set; }
        public IEnumerable<Months> Months { get; set; }

        public FixedAsset FixedAsset { get; set; }
        
        [Display(Name = "Asset No.")]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Branch")]
        [Required]
        public int BranchId { get; set; }

        [Display(Name = "Location")]
        [Required]
        public int LocationId { get; set; }

        [Display(Name = "Staff Assigned")]
        public string StaffAssigned { get; set; }

        [Display(Name = "Initial Cost")]
        public decimal? InitialCost { get; set; }

        [Display(Name = "Asset Status")]
        [Required]
        public int AssetStatusId { get; set; }

        [Display(Name = "Serial Number")]
        [Required]
        public long? SerialNo { get; set; }

        [Display(Name = "Purchases Order No.")]
        public long? PurchasesOrderNo { get; set; }

        public string Model { get; set; }

        [Display(Name = "Purchase Recpt. No.")]
        [Required]
        public long? PurchaseRecptNo { get; set; }

        [Display(Name = "Vendor")]
        [Required]
        public int VendorId { get; set; }

        [Display(Name = "Year of Manufac.")]
        [Required]
        //[DataType(DataType.Date)]
        [Range(2000, 5055)]
        public int? YearOfManufacture { get; set; }

        [Display(Name = "Purchase Date")]
        [Required]
        //[DataType(DataType.Date)]
        public DateTime PurchasedDate { get; set; }

        [Required]
        [Display(Name = "Asset Acc No.")]
        public long? AssetAccountNo { get; set; }

        [Display(Name = "Engine No.")]
        public long? EngineNo { get; set; }

        [Display(Name = "Classic No.")]
        public long? ClassicNo { get; set; }

        [Display(Name = "Maintenance Interval")]
        public int AssetMaintenanceIntervalId { get; set; }


        [Display(Name = "Maintenance Fig.")]
        public int? MaintenanceFigure { get; set; }
        public decimal? PresentValue { get; set; }
        public DateTime? DateRegistered { get; set; }

        public DateTime? LastValuationDate { get; set; }
        public int? DeprIntervalId { get; set; }
        public int? LifeSpan { get; set; }
        public int? MonthsId { get; set; }
        public DateTime? LastDeprYear { get; set; }
        public decimal? Residual { get; set; }
        public decimal? AnnualDeprAmount { get; set; }
        public decimal? DepreciationRate { get; set; }
        public DateTime? LastDeprDate { get; set; }
        public decimal? LastDeprAmt { get; set; }
        public decimal? DeprYTD { get; set; }
        public decimal? DeprToDate { get; set; }
        public int? GLDebitAcc { get; set; }
        public int? GLCreditAcc { get; set; }
        public int? DepreciationMTDId { get; set; }
        public int CompanyId { get; set; }

        public RegisterAssetViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                if (FixedAsset != null && FixedAsset.Id != 0)
                    return "Edit Assets in Register";
                return "Asset Register";
            }
        }

        public RegisterAssetViewModel(FixedAsset fa)
        {
            Id = fa.Id;
            Description = fa.Description;
            CategoryId = fa.CategoryId;
            BranchId = fa.BranchId;
            LocationId = fa.LocationId;
            StaffAssigned = fa.StaffAssigned;
            InitialCost = fa.InitialCost;
            AssetStatusId = fa.AssetStatusId;
            SerialNo = fa.SerialNo;
            PurchasesOrderNo = fa.PurchasesOrderNo;
            Model = fa.Model;
            PurchaseRecptNo = fa.PurchaseRecptNo;
            VendorId = fa.VendorId;
            YearOfManufacture = fa.YearOfManufacture;
            PurchasedDate = fa.PurchasedDate;
            AssetAccountNo = fa.AssetAccountNo;
            EngineNo = fa.EngineNo;
            ClassicNo = fa.ClassicNo;
            AssetMaintenanceIntervalId = fa.AssetMaintenanceIntervalId;
            MaintenanceFigure = fa.MaintenanceFigure;
            CompanyId = fa.CompanyId;

            PresentValue = fa.PresentValue;
            DateRegistered = fa.DateRegistered;
            LastValuationDate = fa.LastValuationDate;
            DeprIntervalId = fa.DeprIntervalId;
            LifeSpan = fa.LifeSpan;
            MonthsId = fa.MonthsId;
            LastDeprYear = fa.LastDeprYear;
            Residual = fa.Residual;
            AnnualDeprAmount = fa.AnnualDeprAmount;
            DepreciationRate = fa.DepreciationRate;
            LastDeprDate = fa.LastDeprDate;
            LastDeprAmt = fa.LastDeprAmt;
            DeprYTD = fa.DeprToDate;
            DeprToDate = fa.DeprToDate;
            GLDebitAcc = fa.GLDebitAcc;
            GLCreditAcc = fa.GLCreditAcc;
            DepreciationMTDId = fa.DepreciationMTDId;
        }
    }
}