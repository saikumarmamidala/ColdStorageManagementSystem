using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class OutgoingLogistic
    {
        [Key]
        public int OutgoingLogisticID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OutgoingLogisticDate { get; set; }
        public string OutgoingLogisticName { get; set; }
        public decimal OutgoingLogisticCost { get; set; }
        public Int64 OutgoingLogisticQuantity { get; set; }
        public string OutgoingLogisticLocation { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}