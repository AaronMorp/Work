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
    public class CreateInvoiceModel
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public int TotalAmount { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Due Date Required")]
        public DateTime DueDate { get; set; }
        public string XeroInvoiceCode { get; set; }
        public string InvoiceType { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public int OriginalCost { get; set; }
        public int EstimatedCost { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
        public decimal? Due { get; set; }
        public string Reference { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime PeriodStart { get; set; }
        public IEnumerable<InvoiceLine> InvoiceLine { get; set; }
    }
}