using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
    public class ReportViewsController : Controller
    {
        private ApplicationDbContext _context;

        public ReportViewsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: ReportViews
        public ActionResult Index()
        {
            return View();
        }

        /*  public ActionResult AssetsDetailReport(string option, string search)
          {
              if(option == "CompCode")
              {
                  return View(_context.FixedAssets.Where(x => x.CompanyId.ToString() == search || search == null).ToList());
              }

              else if (option == "Branch")
              {
                  return View(_context.FixedAssets.Where(x => x.BranchId.ToString() == search || search == null).ToList());
              }

              else if (option == "Category")
              {
                  return View(_context.FixedAssets.Where(x => x.CategoryId.ToString() == search || search == null).ToList());
              }

              else if (option == "Location")
              {
                  return View(_context.FixedAssets.Where(x => x.LocationId.ToString() == search || search == null).ToList());
              }

              else
              {
                  return View();
              }
          } */

        public ActionResult VehicleListing(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }

        public ActionResult AssetsDetailReport(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }

        public ActionResult AssetDepreciationReport(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }

        public ActionResult InsuranceReport(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }
        public ActionResult InspectionReport(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }

        public ActionResult CustomerListing(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }
        public ActionResult AssetDisposal(string option)
        {
            var categories = _context.Categories.ToList();
            var branches = _context.Branches.ToList();
            var locations = _context.Locations.ToList();
            var companies = _context.Companies.ToList();

            var viewModel = new RegisterAssetViewModel
            {
                Categories = categories,
                Branches = branches,
                Locations = locations,
                Companies = companies
            };

            if (option == "Company")
            {
                return View(viewModel);
            }

            else if (option == "Branch")
            {
                return View(viewModel);
            }

            else if (option == "Category")
            {
                return View(viewModel);
            }

            else //if (option == "Location")
            {
                return View(viewModel);
            }
        }
    }
}