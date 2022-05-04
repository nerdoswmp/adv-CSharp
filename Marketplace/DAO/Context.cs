using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class DAOContext : DbContext
    {
        public DbSet<Address> address { get; set; }

        public DbSet<Client> client { get; set; }

        public DbSet<Owner> owner { get; set; }

        public DbSet<Product> product { get; set; }

        public DbSet<Store> store { get; set; }

        public DbSet<Purchase> purchases { get; set; }

        public DbSet<Stocks> stock { get; set; }

        public DbSet<WishList> wishList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (Environment.MachineName == "JVLPC0555")
            {
                optionsBuilder.UseSqlServer(@"Data Source=JVLPC0555\SQLEXPRESS;Initial Catalog=marketplace; Integrated Security = True");
            }
            else
            {
                optionsBuilder.UseSqlServer(@"Data Source=JVLPC0587\SQLSERVER;Initial Catalog=marketplace; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.city).IsRequired();
                entity.Property(e => e.state).IsRequired();
                entity.Property(e => e.country).IsRequired();
                entity.Property(e => e.postal_code).IsRequired();
                entity.Property(e => e.street).IsRequired();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.date_of_birth).IsRequired();
                entity.Property(e => e.phone).IsRequired();
                entity.Property(e => e.login).IsRequired();
                entity.Property(e => e.passwd).IsRequired();
                entity.Property(e => e.document).IsRequired();
                entity.HasOne(e => e.address);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.date_of_birth).IsRequired();
                entity.Property(e => e.phone).IsRequired();
                entity.Property(e => e.login).IsRequired();
                entity.Property(e => e.passwd).IsRequired();
                entity.Property(e => e.document).IsRequired();
                entity.HasOne(e => e.address);
            });
          
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.bar_code).IsRequired();                               
            });         

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.CNPJ).IsRequired();
                entity.HasOne(e => e.owner);
            });

            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.quantity).IsRequired();
                entity.Property(e => e.unit_price).IsRequired();
                entity.HasOne(e => e.product);
                entity.HasOne(e => e.store);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.HasOne(e => e.client);
                entity.HasOne(e => e.product);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.confirmation_number).IsRequired();
                entity.Property(e => e.number_nf).IsRequired();
                entity.Property(e => e.payment_type).IsRequired();
                entity.Property(e => e.purchase_status).IsRequired();
                //entity.Property(e => e.purchase_value).IsRequired();
                entity.Property(e => e.data_purchase).IsRequired();
                entity.HasOne(e => e.store);
                entity.HasOne(e => e.product);
                entity.HasOne(e => e.client);
            });


        }
    }


}
