using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class EndOfYearDto
    {
        public int Id { get; set; }
        public MonthsDto Months { get; set; }
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
    }
}