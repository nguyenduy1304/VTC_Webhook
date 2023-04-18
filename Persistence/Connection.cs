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
                .HasMany(e => e.VTC_Orders)
                .WithOptional(e => e.VTC_MapProducts)
                .HasForeignKey(e => e.Product_Code);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.RefId)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Abaha_Product_Code)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Key_Value)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.RequestId_Activate)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.RequestId_ShippingData)
                .IsUnicode(false);

            modelBuilder.Entity<VTC_Orders>()
                .Property(e => e.Product_Code)
                .IsUnicode(false);
        }
    }
}
