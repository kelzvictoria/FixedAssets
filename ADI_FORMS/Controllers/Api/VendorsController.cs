using ADI_FORMS.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ADI_FORMS.Dtos;

namespace ADI_FORMS.Controllers.Api
{
    public class VendorsController : ApiController
    {
        private ApplicationDbContext _context;
        public VendorsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Vendors
        public IHttpActionResult GetVendors()
        {
            var VendorDtos = _context.Vendors.
                Include(v => v.State).
                Include(v => v.Country).
                ToList().
                Select(Mapper.Map<Vendor, VendorDto>);

                
            return Ok(VendorDtos);
        }

        //GET/api/Vendor/1
        public IHttpActionResult GetVendor(int id)
        {
            var ven = _context.Vendors.SingleOrDefault(c => c.Id == id);
            if (ven == null)
                return NotFound();
            return Ok(Mapper.Map<Vendor, VendorDto>(ven));
        }

        //POST/api/Vendors
        [HttpPost]
        public IHttpActionResult AddNewVendor(VendorDto venDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var ven = Mapper.Map<VendorDto, Vendor>(venDto);
            _context.Vendors.Add(ven);
            _context.SaveChanges();

            venDto.Id = ven.Id;
            return Created(new Uri(Request.RequestUri + "/" + ven.Id), venDto);
        }

        //PUT/api/Vendor/1
        [HttpPut]
        public void UpdateVendor(int id, VendorDto venDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var venInDB = _context.Vendors.SingleOrDefault(c => c.Id == id);
            if (venInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(venDto, venInDB);
            _context.SaveChanges();
        }

        //DELETE/api/Vendor/1
        [HttpDelete]
        public void DeleteVendor(int id)
        {
            var venInDB = _context.Vendors.SingleOrDefault(c => c.Id == id);
            if (venInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Vendors.Remove(venInDB);
            _context.SaveChanges();
        }
    }
}
