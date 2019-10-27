using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class AssetsDetailReport
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public FixedAsset FixedAsset { get; set; }
        //public int FixedAssetId { get; set; }
        [Display(Name="Purchase Date From")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Purchase Date To")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        public SortBy SortBy { get; set; }
        [Display(Name = "Sort By")]
        public int SortById { get; set; }
        

    }
}