using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsMaintenanceCodeViewModel
    {
        public IEnumerable<AssetsMaintenanceCode> AssetsMaintenanceCodes { get; set; }
        public AssetsMaintenanceCode AssetsMaintenanceCode { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public AssetsMaintenanceCodeViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Maintenance Code ";
            }
        }

        public AssetsMaintenanceCodeViewModel(AssetsMaintenanceCode amc)
        {
            Id = amc.Id;
            Name = amc.Name;
        }

    }
}