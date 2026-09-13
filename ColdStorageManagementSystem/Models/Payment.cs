using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan PaymentTime { get; set; }
        
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public decimal PaymentAdvance { get; set; }
        public decimal PaymentDue { get; set; }

    }
}