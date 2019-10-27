using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class EndOfYearViewModel
    {
        public IEnumerable<Months> Month { get; set; }
        public IEnumerable<EndOfYear> EndOfYears { get; set; }
        public EndOfYear EndOfYear { get; set; }
        public int Id { get; set; }
        [Display(Name = "GL Financial Month")]
        public int MonthsId { get; set; }
        [Display(Name = "GL Financial Year")]
        public int FinancialYear { get; set; }
        [Display(Name = "Transactions Period")]
        public string FinancialPeriod { get; set; }
        public string File { get; set; }
        public int RecordNo { get; set; }
        public int NoOfRecords { get; set; }
        public string Information { get; set; }

        public string Title
        {
            get
            {
                return "End of Year Process";
            }
        }
    }
}