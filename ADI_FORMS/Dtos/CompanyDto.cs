using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RCNumber { get; set; }
        public string TaxReference { get; set; }
        public string NPSCode { get; set; }
        public int CurrentYear { get; set; }
        public int CurrentMonth { get; set; }
        public int BudgetedStaff { get; set; }
        public decimal BudgetedSalary { get; set; }
        public decimal UnionDuePercent { get; set; }
        public decimal UnionDueAmount { get; set; }
        public decimal MidMonthPercent { get; set; }
        public decimal AnnualLeavePay { get; set; }
        public decimal MidMonthAmt { get; set; }
        public string LargeCompanyName { get; set; }
        public int? GradeId { get; set; }
        public GradeDto Grade { get; set; }

        public BranchDto Branch { get; set; }
        public int? BranchId { get; set; }

    }
}