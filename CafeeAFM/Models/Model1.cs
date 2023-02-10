using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CafeeAFM.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<add_coffes> add_coffes { get; set; }
        public virtual DbSet<add_sweets> add_sweets { get; set; }
        public virtual DbSet<Addition> Additions { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Book_Infos> Book_Infos { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<Coffee> Coffees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Sweet> Sweets { get; set; }
        public virtual DbSet<Wifi_Infos> Wifi_Infos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Infos>()
                .HasMany(e => e.Services)
                .WithOptional(e => e.Book_Infos)
                .HasForeignKey(e => e.BookID);

            modelBuilder.Entity<Coffee>()
                .Property(e => e.CoffeePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Coffee>()
                .HasMany(e => e.add_coffes)
                .WithOptional(e => e.Coffee)
                .HasForeignKey(e => e.coofe_id);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sweet>()
                .Property(e => e.SweetPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sweet>()
                .HasMany(e => e.add_sweets)
                .WithOptional(e => e.Sweet)
                .HasForeignKey(e => e.sweet_id);

            modelBuilder.Entity<Wifi_Infos>()
                .Property(e => e.Wifi_Price)
                .HasPrecision(19, 4);
        }
    }
}
