namespace AimyInvoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceLine")]
    public partial class InvoiceLine
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set; }

        public decimal? SubsidyPercentage { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [StringLength(200)]
        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Version { get; set; }

        public int? Booking_SptId { get; set; }

        public int? ItemCodeId { get; set; }

        public int? TrackingCatOptionId { get; set; }

        public Guid? XeroLineItemId { get; set; }

        public int? AdditionalInvRefId { get; set; }

        [StringLength(50)]
        public string InvoiceLineType { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}
