using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsInsuranceDetailDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        //public string Class { get; set; }
        public string InsuranceCompany { get; set; }
        public string Address { get; set; }
        public decimal InsuredValue { get; set; }
        public decimal InsurancePremium { get; set; }
        public decimal PremiumToDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFirstInsured { get; set; }
        public decimal PremiumPayable { get; set; }
        public string Interval { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePaid { get; set; }
        public string PayMode { get; set; }
        public int? PolicyNo { get; set; }
    }
}