using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsValuationDetailViewModel
    {
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<DepreciationMTD> DepreciationMTDs { get; set; }
        public IEnumerable<AssetsValuationDetail> AssetsValuationDetails { get; set; }

        public AssetsValuationDetail AssetsValuationDetail { get; set; }
        public int Id { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }

        [Display(Name ="Depr. Method")]
        public int DepreciationMTDId { get; set; }
        [Display(Name="Last Val. Date")]
         public  DateTime? LastValDate{ get; set; }
        public DateTime Eff_Date { get; set; }
        [Display(Name = "New Depr. Method")]
        public string NewDeprMethod { get; set; }
        [Display(Name = "New Lifespan")]
        public int NewLifeSpan { get; set; }
        [Display(Name = "New Residual")]
        public decimal NewResidual { get; set; }
        [Display(Name = "New Depr. Start Date")]
        public DateTime NewDeprStartDate { get; set; }
        [Display(Name = "New Depr. Rate")]
        public decimal NewDeprRate { get; set; }
        [Display(Name = "First Sales Value")]
        public decimal FirstSalesValue { get; set; }
        [Display(Name = "New Depr. To Date")]
        public decimal NewDeprToDate { get; set; }
        [Display(Name = "New Depr. Year To Date")]
        public int NewDeprYearToDate { get; set; }
        [Display(Name = "New Depr. Amt.")]
        public decimal NewDeprAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransDate { get; set; }


        public AssetsValuationDetailViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Valuation Details ";
            }
        }

        public AssetsValuationDetailViewModel(AssetsValuationDetail avl)
        {
            Id = avl.Id;
            LastValDate = avl.LastValDate;
            Eff_Date = avl.Eff_Date;
            NewDeprMethod = avl.NewDeprMethod;
            NewLifeSpan = avl.NewLifeSpan;
            NewResidual = avl.NewResidual;
            NewDeprStartDate = avl.NewDeprStartDate;
            NewDeprRate = avl.NewDeprRate;
            FirstSalesValue = avl.FirstSalesValue;
            NewDeprToDate = avl.NewDeprToDate;
            NewDeprYearToDate = avl.NewDeprYearToDate;
            NewDeprAmount = avl.NewDeprAmount;

            FixedAssetId = avl.FixedAssetId;
            TransDate = avl.TransDate;
            DepreciationMTDId = avl.DepreciationMTDId;
        }
    }
}