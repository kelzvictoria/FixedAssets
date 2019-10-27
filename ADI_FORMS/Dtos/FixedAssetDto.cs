using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class FixedAssetDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public BranchDto Branch { get; set; }
        [Required]
        public int BranchId { get; set; }
        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
        [Required]
        
        public string StaffAssigned { get; set; }
        public decimal? InitialCost { get; set; }
        public AssetStatusDto AssetStatus { get; set; }
        [Required]
        public int AssetStatusId { get; set; }
        //[Required]
        public long? SerialNo { get; set; }
        public long? PurchasesOrderNo { get; set; }

        public string Model { get; set; }
        [Required]
        public long? PurchaseRecptNo { get; set; }
        public VendorDto Vendor { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public int? YearOfManufacture { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchasedDate { get; set; }

        [Required]
        public long? AssetAccountNo { get; set; }
        public long? EngineNo { get; set; }
        public long? ClassicNo { get; set; }

        public AssetMaintenanceIntervalDto AssetMaintenanceInterval { get; set; }

        [Required]
        public int AssetMaintenanceIntervalId { get; set; }

        public CompanyDto Company { get; set; }
        public int CompanyId { get; set; }


        public int? MaintenanceFigure { get; set; }
        public decimal? PresentValue { get; set; }
        public DateTime? DateRegistered { get; set; }
        public DateTime? LastValuationDate { get; set; }
        public string DepreciationInterval { get; set; }
        public int? LifeSpan { get; set; }
        public DateTime? LastDeprMonth { get; set; }
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
        public string DeprMethod { get; set; }
        public DateTime? DeprCommenced { get; set; }
        public DateTime? DeprEndDate { get; set; }

        public DateTime? CurrentYear { get; set; }
    }
}