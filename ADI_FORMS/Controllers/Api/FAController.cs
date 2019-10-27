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
    public class FAController : ApiController
    {
        private ApplicationDbContext _context;
        public FAController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Assets
        public IHttpActionResult GetAssets()
        {
            var assetsDtos = _context.FixedAssets
                .Include(m => m.Category).
                Include(m => m.Location).
                Include(m => m.Branch).
                Include(m => m.Vendor).
                Include(m => m.Company)
                .ToList()
                .Select(Mapper.Map<FixedAsset, FixedAssetDto>);

                
            return Ok(assetsDtos);
        }

        //GET/api/Asset/1
        public IHttpActionResult GetAsset(int id)
        {
            var fa = _context.FixedAssets.SingleOrDefault(f => f.Id == id);
            if (fa == null)
                return NotFound();
            return Ok(Mapper.Map<FixedAsset, FixedAssetDto>(fa));
        }

        //POST/api/Assets
        [HttpPost]
        public IHttpActionResult AddNewAsset(FixedAssetDto faDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var fa = Mapper.Map<FixedAssetDto, FixedAsset>(faDto);
            _context.FixedAssets.Add(fa);
            _context.SaveChanges();

            faDto.Id = fa.Id;
            return Created(new Uri(Request.RequestUri + "/" + fa.Id), faDto);
        }

        //PUT/api/Asset/1
        [HttpPut]
        public void UpdateAsset(int id, FixedAssetDto faDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var faInDB = _context.FixedAssets.SingleOrDefault(f => f.Id == id);
            if (faInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(faDto, faInDB);
            _context.SaveChanges();
        }

        //DELETE/api/Asset/1
        [HttpDelete]
        public void DeleteAsset(int id)
        {
            var faInDB = _context.FixedAssets.SingleOrDefault(f => f.Id == id);
            if (faInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.FixedAssets.Remove(faInDB);
            _context.SaveChanges();
        }
    }
}
