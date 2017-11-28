namespace AimyInvoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            User_Child = new HashSet<User_Child>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public long? EwayCustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int? ContactId { get; set; }

        public int RoleId { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string PasswordHash { get; set; }

        public bool CanLogin { get; set; }

        public string EmailConfirmationToken { get; set; }

        public bool? IsEmailConfirmationValid { get; set; }

        public string PasswordResetToken { get; set; }

        public bool? IsPswResetTokenValid { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime? StaffPayrollLatSyncOn { get; set; }

        public decimal? StaffCostPerHour { get; set; }

        public int? TotalHoursToBeSync { get; set; }

        [StringLength(50)]
        public string Colour { get; set; }

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

        [StringLength(50)]
        public string PinCode { get; set; }

        public bool IsOrgAdmin { get; set; }

        public DateTime? WorkStartDate { get; set; }

        public DateTime? WorkEndDate { get; set; }

        public int? CurrentOrgId { get; set; }

        public DateTime? LastLogedOn { get; set; }

        public int? RetryAttempt { get; set; }

        public bool SysAdmin { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string PasswordBackup { get; set; }

        [StringLength(10)]
        public string EmployeeId { get; set; }

        public bool? QuickRegistered { get; set; }

        public bool? RequiredPasswordChange { get; set; }

        public bool? IsKPFClient { get; set; }

        public bool? IsAimyClient { get; set; }

        public bool? IsIncompleteProfile { get; set; }

        public bool? ShowFavourites { get; set; }

        [StringLength(250)]
        public string TimeZoneIdentifier { get; set; }

        [StringLength(50)]
        public string Culture { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string ImportReference { get; set; }

        public virtual Lookup Lookup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Child> User_Child { get; set; }
    }
}
