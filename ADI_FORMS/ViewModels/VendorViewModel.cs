using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class VendorViewModel
    {
        public IEnumerable<Vendor> Vendors { get; set; }
         public IEnumerable<State> States { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public Vendor Vendor { get; set; }
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
        public State State { get; set; }
        [Display(Name = "State")]
        [Required]
        public int StateId { get; set; }
        public Country Country { get; set; }
        [Display(Name = "Country")]
        [Required]
        public int CountryId { get; set; }
        //public Company Company { get; set; }
        //public int CompanyId { get; set; }

        public VendorViewModel()
        {
            Id = 0;
        }

        public string Title
        {
            get
            {
                if (Vendor != null && Vendor.Id != 0)
                    return "Edit Vendors in Register";
                return "Vendors Registration";
            }
        }
        public VendorViewModel(Vendor ven)
        {
            Id = ven.Id;
            Name = ven.Name;
            Address1 = ven.Address1;
            Address2 = ven.Address2;
            StateId = ven.StateId;
            CountryId = ven.CountryId;
            Phone = ven.Phone;
            Email = ven.Email;
            ContactPerson = ven.ContactPerson;
            DateRegistered = ven.DateRegistered;
            OrderPending= ven.OrderPending;
            LastOrder = ven.LastOrder;
            OrderYearToDate = ven.OrderYearToDate;
        }
    }
}