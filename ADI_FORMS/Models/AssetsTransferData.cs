using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADI_FORMS.Models;

namespace ADI_FORMS.Models
{
    public class AssetsTransferData
    {
        public int Id { get; set; }
        public FixedAsset FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        //public Location Location { get; set; }
        //public int LocationId { get; set; }
        public string NewLocation { get; set; }
        //public Company Company { get; set; }
        //public int CompanyId { get; set; }
        public string NewCompany { get; set; }
        //public Branch Branch { get; set; }
        //public int BranchId { get; set; }
        public string NewBranch { get; set; }
        public DateTime TransferDate { get; set; }
    }
}