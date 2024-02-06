using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TheWayShopProject.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAILs { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.ADMIN_NAME)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.ADMIN_EMAIL)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.ADMIN_PASSWORD)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.ADMIN_CONTACT)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.ADMIN_ADDRESS)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CATEGORY1)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CATEGORY_FID);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDERDETAILs)
                .WithOptional(e => e.ORDER)
                .HasForeignKey(e => e.ORDER_FID);

            modelBuilder.Entity<Product>()
                .Property(e => e.PRODUCT_NAME)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.PRODUCT_DECRIPTION)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.PRODUCT_PICTURE)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ORDERDETAILs)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.PRODUCT_FID);
        }
    }
}
