﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace New_Leaves.Models
{
    [MetadataType(typeof(RefugeeMetadata))]
    public partial class Refugee
    {
        
       
        public string ConfirmNewPassword { get; set; }        
        public string OldConfirmPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class RefugeeMetadata
    {
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Please enter your old password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Old password required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]    
        public string OldConfirmPassword { get; set; }

        [Display(Name = "New Password")]
     
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "New password required")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password required")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm new password and new password do not match")]
        public string ConfirmNewPassword { get; set; }

        
        public string RefugeeFName { get; set; }
        public string RefugeeLName { get; set; }
        public string AuthorityCode { get; set; }        
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Family_Description { get; set; }
        public string Icon { get; set; }
    }
}