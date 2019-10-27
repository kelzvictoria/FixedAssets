using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class VendorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public long Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Required]
        [Display(Name = "Date Registered")]
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }
        [Display(Name = "Order Pending")]
        [Required]
        public decimal OrderPending { get; set; }
        [Required]
        [Display(Name = "Last Order")]
        [DataType(DataType.Date)]
        public DateTime LastOrder { get; set; }
        [Display(Name = "Order Year To Date")]
        [Required]
        public decimal OrderYearToDate { get; set; }
        public StateDto State { get; set; }
        [Display(Name = "State")]
        [Required]
        public int StateId { get; set; }
        public CountryDto Country { get; set; }
        [Display(Name = "Country")]
        [Required]
        public int CountryId { get; set; }
    }
}