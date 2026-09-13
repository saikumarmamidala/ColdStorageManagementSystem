using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class Invoice
    {
        [Key]
        public string BillNumber { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int OutgoingLogisticID { get; set; }
        public OutgoingLogistic OutgoingLogistic { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public Int64 OutgoingLogisticQuantity { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Time { get; set; }

    }
}