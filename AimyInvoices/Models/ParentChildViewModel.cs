using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AimyInvoices.Models
{
    public class ParentChildViewModel
    {
        public int Id { get; set; }

        public int BillingId { get; set; }

        public int StatusId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
     
        public IList<Child> Children { get; set; }

        public string Reference { get; set; }

        public decimal? AmountDue { get; set; }

        public DateTime DueDate { get; set; }

        public decimal? TotalAmount { get; set; }  

        public DateTime? InvoiceDate { get; set; }

        public int SiteId { get; set; }

        public decimal? OriginalCost { get; set; }

        public decimal? EstimatedCost { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public int InvoiceId { get; set; }

        public int? Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; internal set; }



    }
}