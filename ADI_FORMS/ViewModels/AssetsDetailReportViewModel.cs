using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsDetailReportViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}