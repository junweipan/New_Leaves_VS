using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace New_Leaves.Models
{
    public class RefugeeLogin
    {

        [Display(Name = "Authority Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code required")]
        public string AuthorityCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        public int RID { get; set; }

        public string RefugeeFName { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}