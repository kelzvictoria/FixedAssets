using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADI_FORMS.Models;
using System.ComponentModel.DataAnnotations;

namespace ADI_FORMS.ViewModels
{
    public class AssetsTransferDataViewModel
    {
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<AssetsTransferData> AssetsTransferDatas { get; set; }
        public AssetsTransferData AssetsTransferData { get; set; }
        public int Id { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [Display(Name ="New Location")]
        public string NewLocation { get; set; }
        [Display(Name ="New Company")]
        public string NewCompany { get; set; }
        [Display(Name ="New Branch")]
        public string NewBranch { get; set; }
        public AssetsTransferDataViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Transfer Details ";
            }
        }
        public AssetsTransferDataViewModel(AssetsTransferData atd)
        {
            Id = atd.Id;
            NewBranch = atd.NewBranch;
            NewLocation = atd.NewLocation;
            NewCompany = atd.NewCompany;
        }

    }
}