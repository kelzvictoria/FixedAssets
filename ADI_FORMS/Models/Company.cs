using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class Company
    {
        [Display(Name ="Company")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name="RC Number")]
        public string RCNumber { get; set; }
        [Display(Name = "Tax Reference")]
        public string TaxReference { get; set; }
        [Display(Name = "NPS Code")]
        public string NPSCode { get; set; }
        [Display(Name = "Current Year")]
        public int CurrentYear { get; set; }
        [Display(Name = "Current Month")]
        public int CurrentMonth { get; set; }
        [Display(Name = "Budgeted Staff")]
        public int BudgetedStaff { get; set; }
        [Display(Name = "Budgeted Salary")]
        public decimal BudgetedSalary { get; set; }
        [Display(Name = "Union Due Percent")]
        public decimal UnionDuePercent { get; set; }
        [Display(Name = "Union Due Amount")]
        public decimal UnionDueAmount{ get; set; }
        [Display(Name = "Mid Month Percent")]
        public decimal MidMonthPercent { get; set; }
        [Display(Name = "Annual Leave Pay")]
        public decimal AnnualLeavePay { get; set; }
        [Display(Name = "Mid Month Amount")]
        public decimal MidMonthAmt { get; set; }
        [Display(Name = "Large Company Name")]
        public string LargeCompanyName { get; set; }
        public Grade Grade { get; set; }
        [Display(Name = "Grade")]
        public int? GradeId { get; set; }

        public Branch Branch { get; set; }
        [Display(Name = "Branch")]
        public int? BranchId { get; set; }


    }
}