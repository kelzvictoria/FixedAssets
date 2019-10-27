using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
	public class AMCController : Controller
	{
		private ApplicationDbContext _context;

		public AMCController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ActionResult MaintenanceCodeDefinition()
		{
			var amc = _context.AssetsMaintenanceCodes.ToList();
			var viewModel = new AssetsMaintenanceCodeViewModel
			{
				AssetsMaintenanceCode = new AssetsMaintenanceCode()
				,AssetsMaintenanceCodes = amc
			};
			return View("MaintenanceCodeDefinition", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var amc = _context.AssetsMaintenanceCodes.SingleOrDefault(f => f.Id == id);
			if (amc == null)
				return HttpNotFound();
			var viewModel = new AssetsMaintenanceCodeViewModel
			{
				AssetsMaintenanceCode = amc
				,AssetsMaintenanceCodes = _context.AssetsMaintenanceCodes.ToList()
			};
			return View("MaintenanceCodeDefinition", viewModel);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Save(AssetsMaintenanceCode AssetsMaintenanceCode)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new AssetsMaintenanceCodeViewModel(AssetsMaintenanceCode)
				{
					AssetsMaintenanceCodes = _context.AssetsMaintenanceCodes.ToList()
				};
				return View("MaintenanceCodeDefinition", viewModel);
			}

			
			if (AssetsMaintenanceCode.Id == 0)
			{
				_context.AssetsMaintenanceCodes.Add(AssetsMaintenanceCode);
			}
			else
			{
				var amcInDb = _context.AssetsMaintenanceCodes.Single(a => a.Id == AssetsMaintenanceCode.Id);
				amcInDb.Name = AssetsMaintenanceCode.Name;
			}
			_context.SaveChanges();
			return RedirectToAction("MaintenanceCodeDefinition", "AMC");
		}
	}
}