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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Assets
        public IHttpActionResult GetCategories()
        {
            var categoryDtos = _context.Categories
                .ToList()
                .Select(Mapper.Map<Category, CategoryDto>);
            return Ok(categoryDtos);
        }
    }
}
