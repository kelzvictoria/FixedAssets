using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
	public class CategoriesController : Controller
	{
		//
		// GET: /Categories/
		private ApplicationDbContext _context;

		public CategoriesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ActionResult CategoryDefinition()
		{
			var Categories = _context.Categories.ToList();
			var viewModel = new CategoryViewModel
			{
				Category = new Category(),
				Categories = Categories
			};
			return View("CategoryDefinition", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var cat = _context.Categories.SingleOrDefault(f => f.Id == id);
			if (cat == null)
				return HttpNotFound();
			var viewModel = new CategoryViewModel
			{
				Category = cat,
				Categories = _context.Categories.ToList()
			};
			return View("CategoryDefinition", viewModel);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Save(Category Category)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CategoryViewModel(Category)
				{
					Categories = _context.Categories.ToList()
				};
				return View("CategoryDefinition", viewModel);
			}

			
			if (Category.Id == 0)
			{
				_context.Categories.Add(Category);
			}
			else
			{
				var catInDb = _context.Categories.Single(a => a.Id == Category.Id);
				catInDb.Name = Category.Name;
			}
			_context.SaveChanges();
			return RedirectToAction("CategoryDefinition", "Categories");
		}
	}
}