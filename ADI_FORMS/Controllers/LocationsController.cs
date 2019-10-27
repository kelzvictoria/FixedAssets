using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
	public class LocationsController : Controller
	{
		private ApplicationDbContext _context;

		public LocationsController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
        }
        public ActionResult LocationDefinition()
        {
            var locations = _context.Locations.ToList();
            var viewModel = new LocationViewModel
            {
                Location = new Location(),
                Locations = locations
            };
            return View("LocationDefinition", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var loc = _context.Locations.SingleOrDefault(f => f.Id == id);
            if (loc == null)
                return HttpNotFound();
            var viewModel = new LocationViewModel
            {
                Location = loc,
                Locations = _context.Locations.ToList()
            };
            return View("LocationDefinition", viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LocationViewModel(location)
                {
                    Locations = _context.Locations.ToList()
                };
                return View("LocationDefinition", viewModel);
            }


            if (location.Id == 0)
            {
                _context.Locations.Add(location);
            }
            else
            {
                var locInDb = _context.Locations.Single(a => a.Id == location.Id);
                locInDb.Name = location.Name;
            }
            _context.SaveChanges();

            return RedirectToAction("LocationDefinition", "Locations");
        }

    }
}