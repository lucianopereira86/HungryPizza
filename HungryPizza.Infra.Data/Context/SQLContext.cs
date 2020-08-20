using HungryPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace HungryPizza.Infra.Data.Context
{
    public class SQLContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestPizza> RequestPizza { get; set; }
        public DbSet<User> User { get; set; }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("user")
                    .HasKey(k => k.Id);
                e
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.ToTable("customer")
                    .HasKey(k => k.Id);
                e
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Pizza>(e =>
            {
                e.ToTable("pizza")
                    .HasKey(k => k.Id);
                e
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Request>(e =>
            {
                e.ToTable("request")
                    .HasKey(k => k.Id);
                e.Property(p => p.CreatedAt).HasColumnName("created_at");

                var converter = new ValueConverter<Guid, string>(
                  v => v.ToString(),
                  v => new Guid(v));

                e.Property(p => p.Uid).HasConversion(converter);
                e
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

                e.Ignore(i => i.RequestPizzas);
            });

            modelBuilder.Entity<RequestPizza>(e =>
            {
                e.ToTable("request_pizza")
                    .HasKey(k => k.Id);
                e
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
