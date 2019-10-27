using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class EndOfMonthViewModel
    {
        public IEnumerable<Months> Month { get; set; }
        public IEnumerable<EndOfMonth> EndOfMonths { get; set; }
        public EndOfMonth EndOfMonth { get; set; }
        public int Id { get; set; }
        [Display(Name="GL Financial Month")]
        public int MonthsId { get; set; }
        [Display(Name = "GL Financial Year")]
        public int FinancialYear { get; set; }
        [Display(Name = "Transactions Period")]
        public string FinancialPeriod { get; set; }
        [Display(Name = "New Assets")]
        public int NewAssets { get; set; }
        public int Revaluation { get; set; }
        public int Insurance { get; set; }
        public int Inspections { get; set; }
        public int Transfers { get; set; }
        public int Disposals { get; set; }
        public int Renewals { get; set; }
        [Display(Name = "Cumm(Bis) Depreciation")]
        public decimal CummB_S { get; set; }
        [Display(Name = "P & L Acct. Depreciation")]
        public decimal PL_Acc { get; set; }
        public bool UpdateAccum { get; set; }
        [Display(Name = "Record Scan")]
        public int RecordScan { get; set; }
        public string Information { get; set; }

        public string Title
        {
            get
            {
                return "End of Month Process";
            }
        }
    }
}