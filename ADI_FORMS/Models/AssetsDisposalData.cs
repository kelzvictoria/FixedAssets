using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Models
{
    public class AssetsDisposalData
    {
        public int Id { get; set; }
        public FixedAsset FixedAsset { get; set; }
        [Display(Name ="Asset")]
        public int FixedAssetId { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Disposal Date")]
        public DateTime DisposalDate { get; set; }
        [Display(Name ="Disposed Value")]
        public decimal DisposedValue { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string Contact { get; set; }
       
    }
}