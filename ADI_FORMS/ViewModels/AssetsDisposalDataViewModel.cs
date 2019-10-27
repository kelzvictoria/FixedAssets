using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsDisposalDataViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<AssetStatus> AssetStatus { get; set; }
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<AssetsDisposalData> AssetsDisposalDatas { get; set; }
        public AssetsDisposalData AssetsDisposalData { get; set; }
        public int Id { get; set; }
        [Display(Name ="Disposed Date")]
        public DateTime DisposalDate { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [Display(Name ="Disposed Value")]
        public decimal DisposedValue { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string Contact { get; set; }

        public AssetsDisposalDataViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Disposal Details ";
            }
        }

        public AssetsDisposalDataViewModel(AssetsDisposalData adt)
        {
            Id = adt.Id;
            DisposedValue = adt.DisposedValue;
            DisposalDate = adt.DisposalDate;
            Recipient = adt.Recipient;
            Address = adt.Address;
            Contact = adt.Contact;

            FixedAssetId = adt.FixedAssetId;
            
        }

    }
}