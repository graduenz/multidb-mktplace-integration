using System.Linq.Expressions;
using Integration.Application.Catalog.Dto;
using Integration.Domain.Catalog.Entities;

namespace Integration.Application.Catalog.Interfaces;

public interface IProductService
{
    Task<ProductDto?> GetProductByIdAsync(Guid id);
    Task<ProductDto?> GetProductBySkuAsync(string sku);
    Task<IList<ProductDto>> GetProductsAsync(Expression<Func<Product, bool>> filter, int pageIndex, int pageSize);
    Task AddProductAsync(ProductDto product);
    Task UpdateProductAsync(ProductDto product);
    Task RemoveProductAsync(string sku);
}