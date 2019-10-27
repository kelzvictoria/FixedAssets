using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class EndOfYear
    {
        public int Id { get; set; }
        public Months Months { get; set; }
        [Display(Name = "GL Financial Month")]
        public int MonthsId { get; set; }
        [Display(Name = "GL Financial Year")]
        public int FinancialYear { get; set; }
        [Display(Name = "Transactions Period")]
        public string FinancialPeriod { get; set; }
        [Display(Name="File...")]
        public string File { get; set; }
        [Display(Name="Updating Records")]
        public int RecordNo { get; set; }
        [Display(Name = "Of")]
        public int NoOfRecords { get; set; }
        public string Information { get; set; }
    }
}