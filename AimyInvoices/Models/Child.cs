namespace AimyInvoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Child")]
    public partial class Child
    {
        public int Id { get; set; }

        public int? ContactId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string KnownName { get; set; }

        public int? EmergencyContact1Id { get; set; }

        public int? EmergencyContact2Id { get; set; }

        public int? YearEnrolled { get; set; }

        [StringLength(50)]
        public string Ethnicity { get; set; }

        [StringLength(50)]
        public string LanguageSpoken { get; set; }

        public bool? CustodyDispute { get; set; }

        public string CustodyDisputeDescription { get; set; }

        public bool? WearsGlasses { get; set; }

        public bool? HearingAid { get; set; }

        public string Instructions { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Version { get; set; }

        public int? SchoolId { get; set; }

        public bool? AllowPhotoTag { get; set; }

        [StringLength(50)]
        public string ClassRoom { get; set; }

        [StringLength(50)]
        public string TeacherName { get; set; }

        public bool? CYF { get; set; }

        public string CYFDescription { get; set; }

        public bool? IsVegererian { get; set; }

        public bool? GlutenFree { get; set; }

        public string Notes { get; set; }

        [StringLength(100)]
        public string ChildDoctorName { get; set; }

        [StringLength(50)]
        public string ChildDoctorContactFixed { get; set; }

        public bool? IsTetanusImmunised { get; set; }

        [StringLength(50)]
        public string SwimmingCompetency { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string Year { get; set; }

        [StringLength(50)]
        public string ChildDoctorContact { get; set; }

        public bool? IsImmunized { get; set; }

        public bool? EpiPen { get; set; }

        public bool? Inhaler { get; set; }
    }
}
