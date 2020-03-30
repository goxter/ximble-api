namespace XimbleApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
            : base("name=AdventureWorks")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.SizeUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductLine)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Class)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Style)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.LineTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.ReceivedQty)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.RejectedQty)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.StockedQty)
                .HasPrecision(9, 2);
        }
    }
}
