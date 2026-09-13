using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class CustomerLoan
    {
        public int CustomerLoanID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CustomerLoanDate { get; set; }
        public int IncomingLogisticID { get; set; }
        public IncomingLogistic IncomingLogistic { get; set; }
        public decimal CustomerLoanAmount { get; set; }
        public string CustomerLoanBankName { get; set; }
        public Int64 CustomerAccountNumber { get; set; }
        public string CustomerLoanBankIFSCCode { get; set; }
    }
}