using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsInspectionDetailsDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        public DateTime InspectionDate { get; set; }
        public string InspectedBy { get; set; }
        public AssetStatusDto AssetStatus { get; set; }
        public int AssetStatusId { get; set; }
        public string Remarks { get; set; }
    }
}