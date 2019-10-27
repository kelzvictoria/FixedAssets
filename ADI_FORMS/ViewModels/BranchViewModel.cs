using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class BranchViewModel
    {
        public IEnumerable<Branch> Branches { get; set; }
        public Branch Branch { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public BranchViewModel()
        {
            Id = 0;
        }

        public BranchViewModel(Branch cat)
        {
            Id = cat.Id;
            Name = cat.Name;
        }

        public string Title
        {
            get
            {
                return "Branch Definition";
            }

        }
    }
}