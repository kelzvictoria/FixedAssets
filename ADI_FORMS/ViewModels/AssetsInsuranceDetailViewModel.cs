using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsInsuranceDetailViewModel
    {
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<AssetsInsuranceDetail> AssetsInsuranceDetails { get; set; }

        public AssetsInsuranceDetail AssetsInsuranceDetail { get; set; }
        public int Id { get; set; }
        [Required]
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [Display(Name="Policy No.")]
        public int? PolicyNo { get; set; }
        [Required]
        [Display(Name="Insurance Company")]
        public string InsuranceCompany { get; set; }
        public string Address { get; set; }
        [Required]
        [Display(Name="Insured Value")]
        public decimal InsuredValue { get; set; }
        [Required]
        [Display(Name="Insurance Prem.")]
        public decimal InsurancePremium { get; set; }
        [Display(Name="Premium To Date")]
        public decimal PremiumToDate { get; set; }
        [Required]
        [Display(Name="Date First Insured")]
        public DateTime DateFirstInsured { get; set; }
        [Required]
        [Display(Name = "Premium Payable")]
        public decimal PremiumPayable { get; set; }
        [Required]
        public string Interval { get; set; }
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        [Display(Name = "Date Paid")]
        public DateTime? DatePaid { get; set; }
        [Display(Name = "Pay Mode")]
        public string PayMode { get; set; }
        [Display(Name = "Period From")]
        public DateTime? PeriodFrom { get; set; }
        [Display(Name = "Period To")]
        public DateTime? PeriodTo { get; set; }
        public AssetsInsuranceDetailViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Insurance Details ";
            }
        }
        public AssetsInsuranceDetailViewModel(AssetsInsuranceDetail ain)
        {
            Id = ain.Id;
            Address = ain.Address;
            InsuredValue = ain.InsuredValue;
            InsurancePremium = ain.InsurancePremium;
            PremiumToDate = ain.PremiumToDate;
            DateFirstInsured = ain.DateFirstInsured;
            PremiumPayable = ain.PremiumPayable;
            Interval = ain.Interval;
            DueDate = ain.DueDate;
            DatePaid = ain.DatePaid;
            PayMode = ain.PayMode;
            PeriodFrom = ain.PeriodFrom;
            PeriodTo = ain.PeriodTo;
            PolicyNo = ain.PolicyNo;

            FixedAssetId = ain.FixedAssetId;
        }
        
    }
}