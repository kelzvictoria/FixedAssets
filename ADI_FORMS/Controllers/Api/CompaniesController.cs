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
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext _context;
        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Companies
        public IHttpActionResult GetCompanies()
        {
            var companyDtos = _context.Companies.
                Include(c => c.Branch).
                Include(c => c.Grade).
                Select(Mapper.Map<Company, CompanyDto>);

                
            return Ok(companyDtos);
        }

        //GET/api/Company/1
        public IHttpActionResult GetCompany(int id)
        {
            var com = _context.Companies.SingleOrDefault(c => c.Id == id);
            if (com == null)
                return NotFound();
            return Ok(Mapper.Map<Company, CompanyDto>(com));
        }

        //POST/api/Companies
        [HttpPost]
        public IHttpActionResult AddNewCompany(CompanyDto comDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var com = Mapper.Map<CompanyDto, Company>(comDto);
            _context.Companies.Add(com);
            _context.SaveChanges();

            comDto.Id = com.Id;
            return Created(new Uri(Request.RequestUri + "/" + com.Id), comDto);
        }

        //PUT/api/Company/1
        [HttpPut]
        public void UpdateCompany(int id, CompanyDto comDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var comInDB = _context.Companies.SingleOrDefault(c => c.Id == id);
            if (comInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(comDto, comInDB);
            _context.SaveChanges();
        }

        //DELETE/api/Company/1
        [HttpDelete]
        public void DeleteCompany(int id)
        {
            var comInDB = _context.Companies.SingleOrDefault(c => c.Id == id);
            if (comInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Companies.Remove(comInDB);
            _context.SaveChanges();
        }
    }
}
