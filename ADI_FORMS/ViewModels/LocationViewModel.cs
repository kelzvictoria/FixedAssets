using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class LocationViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
        public Location Location { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationViewModel()
        {
            Id = 0;
        }

        public LocationViewModel(Location loc)
        {
            Id = loc.Id;
            Name = loc.Name;
        }

        public string Title
        {
            get{
                return "Location Definition";
            }
            
        }
    }
}