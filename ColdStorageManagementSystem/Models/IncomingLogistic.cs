using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class IncomingLogistic
    {
        public int IncomingLogisticID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime IncomingLogisticDate { get; set; }
        public string IncomingLogisticName { get; set; }
        public decimal IncomingLogisticCost { get; set; }
        public Int64 IncomingLogisticQuantity { get; set; }
        public string IncomingLogisticLocation { get; set; }
        public Boolean IncomingLogisticInsurance { get; set; }
        public decimal IncomingLogisticRent { get; set; }
        public int CustomerID { get; set; }
        public Customer  Customer{ get; set; }

    }
}