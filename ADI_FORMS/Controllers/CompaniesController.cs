using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
	public class CompaniesController : Controller
	{
		private ApplicationDbContext _context;

		public CompaniesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult RegisterCompany()
		{
			var grades = _context.Grades.ToList();
			var companies = _context.Companies.ToList();
            var branches = _context.Branches.ToList();

            var viewModel = new CompanyViewModel
            {
                Company = new Company(),
                Grades = grades,
                Companies = companies
                ,
                Branches = branches
			};
			return View("RegisterCompany", viewModel);
		}

		//public ActionResult Edit(int id)
		//{
		//	var com = _context.Companies.SingleOrDefault(c => c.Id == id);
		//	if (com == null)
		//		return HttpNotFound();
		//	var viewModel = new CompanyViewModel
		//	{
		//		Company = com,
		//		Grades = _context.Grades.ToList(),
		//		Companies = _context.Companies.ToList()
  //              ,
  //              Branches = _context.Branches.ToList()
		//	};
		//	return View("RegisterCompany", viewModel);
		//}

		public ActionResult Companies(int id)
		{
			var com = _context.Companies.SingleOrDefault(c => c.Id == id);
			if (com == null)
				return HttpNotFound();
			var viewModel = new CompanyViewModel
			{
				Company = com,
				Grades = _context.Grades.ToList(),
				Companies = _context.Companies.ToList(),
                Branches = _context.Branches.ToList()
			};
			return View("RegisterCompany", viewModel);
		}
		public ActionResult Index()
		{
            var companies = _context.Companies.Include(c => c.Branch).Include(c => c.Grade);
            return View(companies.ToList());
        }

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Save(Company com)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CompanyViewModel(com)
				{
					Grades = _context.Grades.ToList()
                    ,
                    Branches =_context.Branches.ToList()
				};
				return View("RegisterCompany", viewModel);
			}


			if (com.Id == 0)
			{
				//com.DateRegistered = DateTime.Now;
				
				_context.Companies.Add(com);
			}
			else
			{
				var companyInDb = _context.Companies.Single(c => c.Id == com.Id);
				
				companyInDb.Name = com.Name;
				companyInDb.Address = com.Address;
				companyInDb.BranchId = com.BranchId;
				companyInDb.RCNumber = com.RCNumber;
				companyInDb.TaxReference = com.TaxReference;
				companyInDb.NPSCode = com.NPSCode;
				companyInDb.CurrentMonth = com.CurrentMonth;
				companyInDb.BudgetedSalary = com.BudgetedSalary;
				companyInDb.BudgetedStaff = com.BudgetedStaff;
				companyInDb.UnionDuePercent = com.UnionDuePercent;
				companyInDb.UnionDueAmount = com.UnionDueAmount;
				companyInDb.MidMonthPercent = com.MidMonthPercent;
				companyInDb.MidMonthAmt = com.MidMonthAmt;
				companyInDb.AnnualLeavePay = com.AnnualLeavePay;
				companyInDb.LargeCompanyName = com.LargeCompanyName;
				companyInDb.GradeId = com.GradeId;
				companyInDb.CurrentYear = com.CurrentYear;
			}
			_context.SaveChanges();
			return RedirectToAction("RegisterCompany", "Companies");
		}

        // GET: Companies1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _context.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(_context.Branches, "Id", "Name", company.BranchId);
            ViewBag.GradeId = new SelectList(_context.Grades, "Id", "Name", company.GradeId);
            return View(company);
        }

        // POST: Companies1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,RCNumber,TaxReference,NPSCode,CurrentYear,CurrentMonth,BudgetedStaff,BudgetedSalary,UnionDuePercent,UnionDueAmount,MidMonthPercent,AnnualLeavePay,MidMonthAmt,LargeCompanyName,GradeId,BranchId")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(company).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(_context.Branches, "Id", "Name", company.BranchId);
            ViewBag.GradeId = new SelectList(_context.Grades, "Id", "Name", company.GradeId);
            return View(company);
        }

        // GET: Companies1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _context.Companies.Include(c => c.Branch).Include(c => c.Grade).SingleOrDefault(a => a.Id == id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = _context.Companies.Find(id);
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}