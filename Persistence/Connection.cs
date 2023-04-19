using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Persistence
{
    public partial class Connection : DbContext
    {
        public Connection()
            : base("name=Connection")
        {
        }

        public virtual DbSet<VTC_MapProducts> VTC_MapProducts { get; set; }
        public virtual DbSet<VTC_Order_Detail> VTC_Order_Detail { get; set; }
        public virtual DbSet<VTC_Orders> VTC_Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VTC_MapProducts>()
                .Property(e => e.VTC_Product_Code)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_MapProducts>()
                .Property(e => e.VTC_Product_Id)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_MapProducts>()
                .Property(e => e.Abaha_Product_Code)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_MapProducts>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_MapProducts>()
                .HasMany(e => e.VTC_Order_Detail)
                .WithOptional(e => e.VTC_MapProducts)
                .HasForeignKey(e => e.Product_Code);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.RefId_Abaha)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.RefId_Telcohub)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.Key_Value)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.Abaha_Product_Code)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.Product_Code)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.RequestId_Activate)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Order_Detail>()
                .Property(e => e.RequestId_ShippingData)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.RefId)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Total)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .HasMany(e => e.VTC_Order_Detail)
                .WithRequired(e => e.VTC_Orders)
                .HasForeignKey(e => e.RefId_Abaha)
                .WillCascadeOnDelete(false);
        }
    }
}
