using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class CompanyViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Grade> Grades { get; set; }

        public IEnumerable<Branch> Branches { get; set; }
        public Company Company { get; set; }
        [Display(Name = "Company")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "RC Number")]
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
        public decimal UnionDueAmount { get; set; }
        [Display(Name = "Mid Month Percent")]
        public decimal MidMonthPercent { get; set; }
        [Display(Name = "Annual Leave Pay")]
        public decimal AnnualLeavePay { get; set; }
        [Display(Name = "Mid Month Amount")]
        public decimal MidMonthAmt { get; set; }
        [Display(Name = "Large Company Name")]
        public string LargeCompanyName { get; set; }
        [Display(Name = "Grade")]
        public int? GradeId { get; set; }

        //public Branch Branch { get; set; }
        [Display(Name = "Branch")]
        public int? BranchId { get; set; }

        public CompanyViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                if (Company != null && Company.Id != 0)
                    return "Edit Companies in Register";
                return "Company Registration";
            }
        }


        public CompanyViewModel(Company com)
        {
            Id = com.Id;
            Name = com.Name;
            Address = com.Address;
            BranchId = com.BranchId;
            RCNumber = com.RCNumber;
            TaxReference = com.TaxReference;
            NPSCode = com.NPSCode;
            CurrentYear = com.CurrentYear;
            CurrentMonth = com.CurrentMonth;
            BudgetedStaff = com.BudgetedStaff;
            BudgetedSalary = com.BudgetedSalary;
            UnionDuePercent = com.UnionDuePercent;
            UnionDueAmount = com.UnionDueAmount;
            MidMonthPercent = com.MidMonthPercent;
            AnnualLeavePay = com.AnnualLeavePay;
            MidMonthAmt = com.MidMonthAmt;
            LargeCompanyName = com.LargeCompanyName;
            GradeId = com.GradeId;
        }
    }
}