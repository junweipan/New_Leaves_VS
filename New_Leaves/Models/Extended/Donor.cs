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
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "letters only for first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "letters only for last name")]
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "State")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "State required")]
        public string State { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number required")]
        [MinLength(10, ErrorMessage = "Not a proper phone number, phone number should have 10 digits")]
        [MaxLength(10, ErrorMessage = "Not a proper phone number, phone number should have 10 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "phone number must be numeric")]
        public string Phone { get; set; }

        [Display(Name = "Postcode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postcode required")]
        [MinLength(4, ErrorMessage = "Not a correct postcode, the postcode has 4 digits")]
        [MaxLength(4, ErrorMessage = "Not a correct postcode, the postcode has 4 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "postcode must be numeric")]
        public string Postcode { get; set; }

        [Display(Name = "Street")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address required")]
        public string Street { get; set; }

        [Display(Name = "Suburb")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Suburb required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "letters only for suburb name")]
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