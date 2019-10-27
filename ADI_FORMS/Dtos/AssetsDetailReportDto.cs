using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsDetailReportDto
    {
        public int Id { get; set; }
        public CompanyDto Company { get; set; }
        public int CompanyId { get; set; }
        public BranchDto Branch { get; set; }
        public int BranchId { get; set; }
        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
        public LocationDto Location { get; set; }
        public int LocationId { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public SortByDto SortBy { get; set; }
        public int SortById { get; set; }
    }
}