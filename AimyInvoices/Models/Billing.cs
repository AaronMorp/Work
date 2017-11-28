namespace AimyInvoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Billing")]
    public partial class Billing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Billing()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int SiteId { get; set; }

        public int? PromoCodeId { get; set; }

        public int? PaymentOptionId { get; set; }

        public int? TermId { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal? OriginalCost { get; set; }

        public decimal? EstimatedCost { get; set; }

        public decimal? FinalCost { get; set; }

        public decimal? EstimatedOscar { get; set; }

        public bool? HasSentToXero { get; set; }

        public decimal? PromoAmount { get; set; }

        public decimal? PromoPercentage { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Version { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public int? BookingTemplateId { get; set; }

        public decimal? TotalExtraInvLineAmount { get; set; }

        [StringLength(50)]
        public string ExtraLineType { get; set; }

        public string ParentNotes { get; set; }

        public bool? OscarIntended { get; set; }

        public bool? IsMadeFromTemplate { get; set; }

        public bool? IsQuickBooked { get; set; }

        public bool? RollOverIntended { get; set; }

        public bool? IsRollOvered { get; set; }

        public bool? IsInvFreqChanged { get; set; }

        public int? ByTemplateQueueId { get; set; }

        public bool? IsChargeByAttendance { get; set; }

        public bool? MakeAllInvPeriodSamePrice { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
