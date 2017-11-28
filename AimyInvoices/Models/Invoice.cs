namespace AimyInvoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int Id { get; set; }

        public int BillingId { get; set; }

        public int StatusId { get; set; }

        public Guid? XeroInvoiceId { get; set; }

        [StringLength(200)]
        public string XeroInvoiceCode { get; set; }

        [StringLength(300)]
        public string Reference { get; set; }

        [Required]
        public string Email { get; set; }

        public decimal? Discount { get; set; }

        [StringLength(500)]
        public string DiscountReason { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public decimal? AmountDue { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? AmountCredited { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public bool Error { get; set; }

        public string ErrorDescription { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? OriginalTotalAmount { get; set; }

        public DateTime? XeroUpdatedDateUTC { get; set; }

        public string InvoiceType { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(200)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Version { get; set; }

        [StringLength(50)]
        public string EmailStatus { get; set; }

        public string EmailToken { get; set; }

        public DateTime? LastAttDate { get; set; }

        public DateTime? FirstAttDate { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public virtual Billing Billing { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; internal set; }
    }
}
