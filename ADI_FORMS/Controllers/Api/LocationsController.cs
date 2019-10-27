using ADI_FORMS.Dtos;
using ADI_FORMS.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace ADI_FORMS.Controllers.Api
{
    public class LocationsController : ApiController
    {
        private ApplicationDbContext _context;
        public LocationsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Assets
        public IHttpActionResult GetLocations()
        {
            var locationDtos = _context.Locations
                .ToList()
                .Select(Mapper.Map<Location, LocationDto>);
            return Ok(locationDtos);
        }

        [HttpPost]
        public IHttpActionResult AddLocation(LocationDto locDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var loc = Mapper.Map<LocationDto, Location>(locDto);
            _context.Locations.Add(loc);
            _context.SaveChanges();

            locDto.Id = loc.Id;
            return Created(new Uri(Request.RequestUri + "/" + loc.Id), locDto);
        }
    }
}
