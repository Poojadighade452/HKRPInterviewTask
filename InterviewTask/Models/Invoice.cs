﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace InterviewTask.Models
{
    public partial class Invoice
    {
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }
        public int? MobileNumber { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PaidAmount { get; set; }
        public string PaymentMode { get; set; }
    }
}