using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class AssetsValuationDetail
    {
        public int Id { get; set; }
        public FixedAsset FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        public DepreciationMTD DepreciationMTD { get; set; }
        public int DepreciationMTDId { get; set; }
        public  DateTime? LastValDate{ get; set; }
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
        [DataType(DataType.Date)]
        public DateTime TransDate { get; set; }

    }
}