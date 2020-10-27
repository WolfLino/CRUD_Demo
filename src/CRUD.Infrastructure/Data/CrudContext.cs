using CRUD.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(ConfigureCustomer);
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.DateOfBirth)
                .IsRequired();

            builder.Property(c => c.Gender)
                .IsRequired();
        }
    }
}
