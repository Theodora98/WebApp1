using Microsoft.EntityFrameworkCore;
using PapaPizzaria.Models;

namespace PapaPizzaria.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext (DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<StoreAssignment> StoreAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(Product))
                .HasMany(c => c.Deliveries)
                .WithMany(i => i.Products);
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            modelBuilder.Entity<Delivery>().ToTable(nameof(Delivery));
             modelBuilder.Entity<Store>()
            .Property(d => d.ConcurrencyToken)
            .IsConcurrencyToken();
        }
    }
}