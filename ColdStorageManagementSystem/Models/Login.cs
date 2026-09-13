using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "Enter Valid Id!")]
        [Display(Name = "Customer ID")]
        public int LoginID { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        [Display(Name = "Password")]
        public string LoginPwd { get; set; }
    }
}