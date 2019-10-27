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
    public class BranchesController : ApiController
    {
        private ApplicationDbContext _context;
        public BranchesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Assets
        public IHttpActionResult GetBranches()
        {
            var branchDtos = _context.Branches
                .ToList()
                .Select(Mapper.Map<Branch, BranchDto>);
            return Ok(branchDtos);
        }
    }
}
