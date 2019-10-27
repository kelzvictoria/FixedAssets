using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsTransferDataDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
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