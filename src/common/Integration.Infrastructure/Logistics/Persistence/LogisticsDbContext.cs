using System.Reflection;
using Integration.Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integration.Infrastructure.Logistics.Persistence;

public class LogisticsDbContext : DbContext
{
    public DbSet<Center> Centers { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}