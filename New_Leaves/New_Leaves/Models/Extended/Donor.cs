using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace New_Leaves.Models

{
    [MetadataType(typeof(DonorMetadata))]
    public partial class Donor
    {
        public string ConfirmPassword { get; set; }
    }

    public class DonorMetadata
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "State")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string State { get; set; }

        [Display(Name = "Phone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string Phone { get; set; }

        [Display(Name = "Postcode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string Postcode { get; set; }

        [Display(Name = "Street")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string Street { get; set; }

        [Display(Name = "Suburb")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string Suburb { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }

    }
}