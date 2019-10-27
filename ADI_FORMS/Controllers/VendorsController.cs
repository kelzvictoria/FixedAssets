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
	public class VendorsController : Controller
	{
		private ApplicationDbContext _context;

		public VendorsController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult RegisterVendor()
		{
			var states = _context.States.ToList();
			var countries = _context.Countries.ToList();
			var vendors = _context.Vendors.ToList();

			var viewModel = new VendorViewModel
			{
				Vendor = new Vendor(),
				States = states,
				Countries = countries,
				Vendors = vendors
			};
			return View("RegisterVendor", viewModel);
		}

        public ActionResult RegisterVendorAdmin()
        {
            var states = _context.States.ToList();
            var countries = _context.Countries.ToList();
            var vendors = _context.Vendors.ToList();

            var viewModel = new VendorViewModel
            {
                Vendor = new Vendor(),
                States = states,
                Countries = countries,
                Vendors = vendors
            };
            return View("RegisterVendorAdmin", viewModel);
        }

  //      public ActionResult Edit(int id)
		//{
		//	var ven = _context.Vendors.SingleOrDefault(v => v.Id == id);
		//	if (ven == null)
		//		return HttpNotFound();
		//	var viewModel = new VendorViewModel
		//	{
		//		Vendor = ven,
		//		States = _context.States.ToList(),
		//		Countries = _context.Countries.ToList(),
		//		Vendors = _context.Vendors.ToList()
		//	};
		//	return View("RegisterVendorAdmin", viewModel);
		//}

		public ActionResult Vendors(int id)
		{
			var vend = _context.Vendors.SingleOrDefault(c => c.Id == id);
			if (vend == null)
				return HttpNotFound();
			var viewModel = new VendorViewModel
			{
				Vendor = vend,
				States = _context.States.ToList(),
				Countries = _context.Countries.ToList(),
				Vendors = _context.Vendors.ToList()
			};
			return View("RegisterVendor", viewModel);
		}
		public ActionResult Index()
		{
            var vendors = _context.Vendors.Include(v => v.Country).Include(v => v.State);
            return View(vendors.ToList());
        }

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Save(Vendor vend)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new VendorViewModel(vend)
				{
					States = _context.States.ToList(),
					Countries = _context.Countries.ToList()
				};
				return View("RegisterVendor", viewModel);
			}

			if (vend.Id == 0)
			{
				vend.DateRegistered = DateTime.Now;
				
				_context.Vendors.Add(vend);
			}
			else
			{
				var VendorInDb = _context.Vendors.Single(c => c.Id == vend.Id);
				
				VendorInDb.Name = vend.Name;
				VendorInDb.Address1 = vend.Address1;
				VendorInDb.Address2 = vend.Address2;
				VendorInDb.StateId = vend.StateId;
				VendorInDb.CountryId = vend.CountryId;
				VendorInDb.Phone = vend.Phone;
				VendorInDb.Email = vend.Email;
				VendorInDb.ContactPerson = vend.ContactPerson;
				VendorInDb.DateRegistered = vend.DateRegistered;
				VendorInDb.OrderPending = vend.OrderPending;
				VendorInDb.LastOrder = vend.LastOrder;
				VendorInDb.OrderYearToDate = vend.OrderYearToDate;
			}
			_context.SaveChanges();
			return RedirectToAction("RegisterVendor", "Vendors");
		}

        // GET: Vendors1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _context.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name", vendor.CountryId);
            ViewBag.StateId = new SelectList(_context.States, "Id", "Name", vendor.StateId);
            return View(vendor);
        }

        // POST: Vendors1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address1,Address2,Phone,Email,ContactPerson,DateRegistered,OrderPending,LastOrder,OrderYearToDate,StateId,CountryId")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(vendor).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name", vendor.CountryId);
            ViewBag.StateId = new SelectList(_context.States, "Id", "Name", vendor.StateId);
            return View(vendor);
        }

        // GET: Vendors1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _context.Vendors.Include(a => a.Country).Include(a => a.State).SingleOrDefault(a => a.Id == id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = _context.Vendors.Find(id);
            _context.Vendors.Remove(vendor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}