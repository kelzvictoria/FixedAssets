using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
	public class EOMController : Controller
	{
		private ApplicationDbContext _context;

		public EOMController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		//
		// GET: /EOM/
		public ActionResult EndOfMonth()
		{
			var months = _context.Months.ToList();
			var endOfMonths = _context.EndOfMonth.ToList();

			var viewModel = new EndOfMonthViewModel
			{
				EndOfMonth = new EndOfMonth(),
				Month = months,
				EndOfMonths = endOfMonths

			};
			return View("EndOfMonth", viewModel);
		}
	}
}