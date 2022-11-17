using Integration.Domain.Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.Catalog.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.Category)
            .WithMany(m => m.Products)
            .HasForeignKey(m => m.CategoryId);
    }
}