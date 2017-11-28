namespace AimyInvoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            Children = new HashSet<Child>();
            Children1 = new HashSet<Child>();
            Children2 = new HashSet<Child>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public int? GenderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "image")]
        public byte[] SignatureImage { get; set; }

        [StringLength(50)]
        public string LandlineFixed { get; set; }

        [StringLength(50)]
        public string OfficeFixed { get; set; }

        [StringLength(50)]
        public string OfficeExtension { get; set; }

        [StringLength(50)]
        public string FaxFixed { get; set; }

        [StringLength(50)]
        public string MobileFixed { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string StreetNum { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Suburb { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Postcode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string BillingStreetNum { get; set; }

        [StringLength(500)]
        public string BillingAddress { get; set; }

        [StringLength(50)]
        public string BillingSuburb { get; set; }

        [StringLength(50)]
        public string BillingCity { get; set; }

        [StringLength(50)]
        public string BillingPostcode { get; set; }

        [StringLength(50)]
        public string BillingCountry { get; set; }

        [StringLength(50)]
        public string OscarNum { get; set; }

        public DateTime? ReviewDate { get; set; }

        [StringLength(50)]
        public string Relation { get; set; }

        [StringLength(50)]
        public string HowHear { get; set; }

        [StringLength(50)]
        public string Lat { get; set; }

        [StringLength(50)]
        public string Lng { get; set; }

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

        public bool FirstAidCheck { get; set; }

        public DateTime? FirstAidExpireyDate { get; set; }

        public bool PoliceCheck { get; set; }

        public DateTime? PoliceCheckExprieyDate { get; set; }

        public bool? ChildcareCertificate { get; set; }

        public DateTime? ChildcareCertiIssueDate { get; set; }

        [StringLength(20)]
        public string ChildCareCertiNum { get; set; }

        public string Notes { get; set; }

        [StringLength(50)]
        public string DriverLicence { get; set; }

        [StringLength(50)]
        public string Landline { get; set; }

        [StringLength(50)]
        public string Office { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(250)]
        public string SocialWorkerId { get; set; }

        public string OtherRelation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Child> Children { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Child> Children1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Child> Children2 { get; set; }
    }
}
