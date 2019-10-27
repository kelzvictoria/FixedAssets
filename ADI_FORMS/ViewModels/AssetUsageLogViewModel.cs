using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class AssetUsageLogViewModel
    {
        public IEnumerable<FixedAsset> FixedAssets { get; set; }
        public IEnumerable<AssetUsageLog> AssetUsageLogs { get; set; }

        public AssetUsageLog AssetUsageLog { get; set; }
        public int Id { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [Display(Name="Transaction Date")]
        public DateTime Trans_Date { get; set; }
        [Display(Name="Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name="End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name="End Time")]
        public DateTime EndTime { get; set; }
        public string Destination { get; set; }
        [Display(Name="Staff Identification")]
        public string StaffIdentification { get; set; }

        public AssetUsageLogViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                return "Assets Usage Log";
            }
        }

        public AssetUsageLogViewModel(AssetUsageLog aul)
        {
            Id = aul.Id;
            Trans_Date = aul.Trans_Date;
            StartTime = aul.StartTime;
            EndDate = aul.EndDate;
            Destination = aul.Destination;
            StaffIdentification = aul.StaffIdentification;

            FixedAssetId = aul.FixedAssetId;

        }


    }
}