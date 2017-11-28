namespace AimyInvoices.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InvoiceContext : DbContext
    {
        public InvoiceContext()
            : base("name=InvoiceModel")
        {
//            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<Billing> Billing { get;  set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Child> User_Child { get;  set; }
        public virtual DbSet<Child> Child { get;  set; }
        public virtual DbSet<Lookup> Lookup { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          /*  modelBuilder.Entity<Invoice>()
                .Property(e => e.Discount)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Version)
                .IsFixedLength();

            modelBuilder.Entity<InvoiceLine>()
                .Property(e => e.Version)
                .IsFixedLength();*/
        }

        public System.Data.Entity.DbSet<AimyInvoices.Models.ParentChildViewModel> ParentChildViewModels { get; set; }
    }
}
