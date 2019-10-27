using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class AssetsInsuranceDetail
    {
        public int Id { get; set; }
        
        public FixedAsset FixedAsset { get; set; }
        [Required]
        public int FixedAssetId { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        //public string Class { get; set; }
        [Required]
        public string InsuranceCompany { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal InsuredValue { get; set; }
        [Required]
        public decimal InsurancePremium { get; set; }
        public decimal PremiumToDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFirstInsured { get; set; }
        [Required]
        public decimal PremiumPayable { get; set; }
        [Required]
        public string Interval { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatePaid { get; set; }
        public string PayMode { get; set; }
        public int? PolicyNo { get; set; }
    }
}