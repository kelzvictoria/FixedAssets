using ADI_FORMS.Dtos;
using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace ADI_FORMS.Controllers.Api
{
    public class AMDController : ApiController
    {
        private ApplicationDbContext _context;
        public AMDController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/AssetsMaintenanceDetails
        public IHttpActionResult GetAssetsMaintenaceDetails()
        {
            var amdDtos = _context.AssetsMaintenanceDetails
                .Include(m => m.FixedAsset)
                .ToList()
                .Select(Mapper.Map<AssetsMaintenanceDetails, AssetsMaintenanceDetailsDto>);
            return Ok(amdDtos);
        }

        //GET/api/AssetMaintenanceDetails/1
        public IHttpActionResult GetAssetMaintenanceDetail(int id)
        {
            var amd = _context.AssetsMaintenanceDetails.SingleOrDefault(m => m.Id == id);
            if (amd == null)
                return NotFound();
            return Ok(Mapper.Map<AssetsMaintenanceDetails, AssetsMaintenanceDetailsDto>(amd));
        }

        //POST/api/AssetsMaintenanceDetails
        [HttpPost]
        public IHttpActionResult AddNewAssetsMaintenanceDetail(AssetsMaintenanceDetailsDto amDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var amd = Mapper.Map<AssetsMaintenanceDetailsDto, AssetsMaintenanceDetails>(amDto);
            _context.AssetsMaintenanceDetails.Add(amd);
            _context.SaveChanges();

            amDto.Id = amd.Id;
            return Created(new Uri(Request.RequestUri + "/" + amd.Id), amDto);
        }

        //PUT/api/AssetsMaintenanceDetail/1
        [HttpPut]
        public void UpdateAssetsMaintenanceDetail(int id, AssetsMaintenanceDetailsDto amDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var amInDB = _context.AssetsMaintenanceDetails.SingleOrDefault(m => m.Id == id);
            if (amInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(amDto, amInDB);
            _context.SaveChanges();
        }

        //DELETE/api/Asset/1
        [HttpDelete]
        public void DeleteAssetsMaintenanceDetail(int id)
        {
            var amdInDB = _context.AssetsMaintenanceDetails.SingleOrDefault(m => m.Id == id);
            if (amdInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.AssetsMaintenanceDetails.Remove(amdInDB);
            _context.SaveChanges();
        }
    }
}
