using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class EndOfMonthDto
    {
        public int Id { get; set; }
        public MonthsDto Months { get; set; }
        public int MonthsId { get; set; }
        public int FinancialYear { get; set; }
        public string FinancialPeriod { get; set; }
        public int NewAssets { get; set; }
        public int Revaluation { get; set; }
        public int Insurance { get; set; }
        public int Inspections { get; set; }
        public int Transfers { get; set; }
        public int Disposals { get; set; }
        public int Renewals { get; set; }
        public decimal CummB_S { get; set; }
        public decimal PL_Acc { get; set; }
        public bool UpdateAccum { get; set; }
        public int RecordScan { get; set; }
        public string Information { get; set; }
    }
}