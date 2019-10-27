using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsValuationDetailDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        public DepreciationMTDDto DepreciationMTD { get; set; }
        public int DepreciationMTDId { get; set; }
        public int? LifeSpan { get; set; }
        public DateTime? LastValDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Eff_Date { get; set; }
        public string NewDeprMethod { get; set; }
        public int NewLifeSpan { get; set; }
        public decimal NewResidual { get; set; }
        [DataType(DataType.Date)]
        public DateTime NewDeprStartDate { get; set; }
        public decimal NewDeprRate { get; set; }
        public decimal FirstSalesValue { get; set; }
        public decimal NewDeprToDate { get; set; }
        public int NewDeprYearToDate { get; set; }
        public decimal NewDeprAmount { get; set; }
        public DateTime TransDate { get; set; }


    }
}