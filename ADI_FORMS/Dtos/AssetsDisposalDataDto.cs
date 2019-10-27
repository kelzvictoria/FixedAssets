using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsDisposalDataDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DisposalDate { get; set; }
        public decimal DisposedValue { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string Contact { get; set; }
    }
}