using AimyInvoices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AimyInvoices.Models
{
    public class MultipleModel
    {
        public IEnumerable <Invoice> Invoices { get; set; }
        public List<Child> Children { get; set; }
        public List<Billing> Billings { get; set; }
    }
}