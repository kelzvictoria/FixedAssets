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
    public class AMCController : ApiController
    {
        private ApplicationDbContext _context;
        public AMCController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Assets
        public IHttpActionResult GetAssetsMaintenanceCode()
        {
            var amcDtos = _context.AssetsMaintenanceCodes
                .ToList()
                .Select(Mapper.Map<AssetsMaintenanceCode, AssetsMaintenanceCodeDto>);
            return Ok(amcDtos);
        }
    }
}
