using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "Enter Valid Id!")]
        [Display(Name = "Admin ID")]
        public int AdminID { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        [Display(Name = "Password")]
        public string AdminPwd { get; set; }
    }
}