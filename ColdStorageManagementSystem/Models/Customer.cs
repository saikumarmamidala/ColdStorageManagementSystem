using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage="Enter Customer Name")]
        public string CustomerName { get; set; }
         [Required(ErrorMessage = "Enter Customer Phone Number")]
        public Int64 CustomerPhoneNumber { get; set; }
         [Required(ErrorMessage = "Enter Customer EmailID")]
        public string CustomerEmail { get; set; }
         [Required(ErrorMessage = "Enter Customer House Number")]
        public string CustomerHouseNumber { get; set; }
        public string CustomerStreetName { get; set; }
         [Required(ErrorMessage = "Enter Customer City")]
        public string CustomerCity { get; set; }
         [Required(ErrorMessage = "Enter Customer ZipCode")]
        public int CustomerZipCode { get; set; }
         [Required(ErrorMessage = "Enter Customer State")]
        public string CustomerState { get; set; }

         public string CustomerPwd { get; set; }
    }
}