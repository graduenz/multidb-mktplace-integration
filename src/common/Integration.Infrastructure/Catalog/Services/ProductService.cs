using System.Linq.Expressions;
using FluentValidation;
using Integration.Application.Catalog.Dto;
using Integration.Application.Catalog.Interfaces;
using Integration.Application.Interfaces;
using Integration.Application.Models;
using Integration.Domain.Catalog.Entities;
using Integration.Infrastructure.Catalog.Persistence;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Integration.Infrastructure.Catalog.Services;

public class ProductService : IProductService
{
    private readonly CatalogDbContext _catalogDbContext;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDto> _validator;
    private readonly IMessagePublisher _publisher;

    public ProductService(CatalogDbContext catalogDbContext, IMapper mapper, IValidator<ProductDto> validator,
        IMessagePublisher publisher)
    {
        _catalogDbContext = catalogDbContext;
        _mapper = mapper;
        _validator = validator;
        _publisher = publisher;
    }

    public async Task<ProductDto?> GetProductByIdAsync(Guid id) =>
        _mapper.Map<ProductDto>(await _catalogDbContext.Products.FindAsync(id));

    public async Task<ProductDto?> GetProductBySkuAsync(string sku) =>
        _mapper.Map<ProductDto>(await _catalogDbContext.Products.FirstOrDefaultAsync(m => m.Sku == sku));

    public Task<PaginatedList<ProductDto>> GetProductsAsync(Expression<Func<Product, bool>> filter, int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task AddProductAsync(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task RemoveProductAsync(string sku)
    {
        throw new NotImplementedException();
    }
}