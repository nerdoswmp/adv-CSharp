using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> address { get; set; }

        public DbSet<Person> people { get; set; }

        public DbSet<Client> client { get; set; }

        public DbSet<Owner> owner { get; set; }

        public DbSet<Product> product { get; set; }

        public DbSet<Store> store { get; set; }

        public DbSet<Purchase> purchases { get; set; }

        public DbSet<Stocks> stock { get; set; }

        public DbSet<WishList> wishList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=JVLPC0555\SQLEXPRESS;Initial Catalog=bancotest;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.city).IsRequired();
                entity.Property(e => e.state).IsRequired();
                entity.Property(e =>e.country).IsRequired();
                entity.Property(e => e.poste_code).IsRequired();
            });

            //modelBuilder.Entity<Client>(entity =>
            //{
            //    entity.HasKey(e => e.ISBN);
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasOne(d => d.Publisher)
            //      .WithMany(p => p.Books);
            //});
        }
    }


}
