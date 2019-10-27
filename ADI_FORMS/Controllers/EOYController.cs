using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
	public class EOYController : Controller
	{
		private ApplicationDbContext _context;

		public EOYController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		//
		// GET: /EOM/
		public ActionResult EndOfYear()
		{
			var months = _context.Months.ToList();
			var endOfYear = _context.EndOfYears.ToList();

			var viewModel = new EndOfYearViewModel
			{
				EndOfYear = new EndOfYear(),
				Month = months,
				EndOfYears = endOfYear

			};
			return View("EndOfYear", viewModel);
		}
		//
		// GET: /EOY/
		public ActionResult Index()
		{
			return View();
		}
	}
}