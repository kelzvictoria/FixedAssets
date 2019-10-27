using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
    public class BranchesController : Controller
    {

        private ApplicationDbContext _context;

        public BranchesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Definition()
        {
            var Branches = _context.Branches.ToList();
            var viewModel = new BranchViewModel
            {
                Branch = new Branch(),
                Branches = Branches
            };
            return View("Definition", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var cat = _context.Branches.SingleOrDefault(f => f.Id == id);
            if (cat == null)
                return HttpNotFound();
            var viewModel = new BranchViewModel
            {
                Branch = cat,
                Branches = _context.Branches.ToList()
            };
            return View("Definition", viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Branch Branch)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BranchViewModel(Branch)
                {
                    Branches = _context.Branches.ToList()
                };
                return View("Definition", viewModel);
            }


            if (Branch.Id == 0)
            {
                _context.Branches.Add(Branch);
            }
            else
            {
                var catInDb = _context.Branches.Single(a => a.Id == Branch.Id);
                catInDb.Name = Branch.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Definition", "Branches");
        }
        // GET: Branches
        public ActionResult Index()
        {
            return View();
        }
    }
}