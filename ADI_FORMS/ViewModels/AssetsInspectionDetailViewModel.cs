using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetsInspectionDetailViewModel
    {
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<AssetsInspectionDetails> AssetsInspectionDetails { get; set; }
        public IEnumerable<AssetStatus> AssetStatuses { get; set; }

        public AssetsInspectionDetails AssetsInspectionDetail { get; set; }
        public int Id { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [Display(Name ="Status")]
        public int AssetStatusId { get; set; }
        [Display(Name ="Inspection Date")]
        public DateTime InspectionDate { get; set; }
        [Display(Name = "Inspected By")]
        public string InspectedBy { get; set; }
        public string Remarks { get; set; }


        public AssetsInspectionDetailViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Inspection Details ";
            }
        }
        public AssetsInspectionDetailViewModel(AssetsInspectionDetails aInspD)
        {
            Id = aInspD.Id;
            InspectedBy = aInspD.InspectedBy;
            InspectionDate = aInspD.InspectionDate;
            AssetStatusId = aInspD.AssetStatusId;
            Remarks = aInspD.Remarks;
            FixedAssetId = aInspD.FixedAssetId;
        }

    }
}