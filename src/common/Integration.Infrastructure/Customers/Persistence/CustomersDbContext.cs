using System.Reflection;
using Integration.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integration.Infrastructure.Customers.Persistence;

public class CustomersDbContext : DbContext
{
    public CustomersDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}