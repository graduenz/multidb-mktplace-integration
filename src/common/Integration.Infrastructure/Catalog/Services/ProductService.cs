using System.Linq.Expressions;
using FluentValidation;
using Integration.Application.Catalog.Dto;
using Integration.Application.Catalog.Interfaces;
using Integration.Application.Interfaces;
using Integration.Application.Models;
using Integration.Application.Notifications;
using Integration.Domain.Catalog.Entities;
using Integration.Infrastructure.Catalog.Persistence;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Integration.Infrastructure.Catalog.Services;

public class ProductService : IProductService
{
    private const string ProductAlreadyExists = nameof(ProductAlreadyExists);
    private const string ProductDoesNotExist = nameof(ProductDoesNotExist);
    
    private readonly CatalogDbContext _catalogDbContext;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDto> _validator;
    private readonly NotificationHandler _notificationHandler;
    private readonly IMessagePublisher _publisher;

    public ProductService(CatalogDbContext catalogDbContext, IMapper mapper, IValidator<ProductDto> validator,
        NotificationHandler notificationHandler, IMessagePublisher publisher)
    {
        _catalogDbContext = catalogDbContext;
        _mapper = mapper;
        _validator = validator;
        _notificationHandler = notificationHandler;
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

    public async Task AddProductAsync(ProductDto product)
    {
        var validationResult = await _validator.ValidateAsync(product);
        if (!validationResult.IsValid)
        {
            var messages = validationResult.Errors.Select(m => m.ErrorMessage);
            _notificationHandler.AddNotification(Notification.Validation, messages);
            return;
        }

        var entity = await _catalogDbContext.Products.FirstOrDefaultAsync(m => m.Sku == product.Sku);
        if (entity != null)
        {
            _notificationHandler.AddNotification(ProductAlreadyExists, "A product with the given SKU already exists");
            return;
        }

        await _publisher.PublishMessageAsync("integration.product.created", product);
    }

    public async Task UpdateProductAsync(ProductDto product)
    {
        var validationResult = await _validator.ValidateAsync(product);
        if (!validationResult.IsValid)
        {
            var messages = validationResult.Errors.Select(m => m.ErrorMessage);
            _notificationHandler.AddNotification(Notification.Validation, messages);
            return;
        }

        var entity = await _catalogDbContext.Products.FirstOrDefaultAsync(m => m.Sku == product.Sku);
        if (entity == null)
        {
            _notificationHandler.AddNotification(ProductDoesNotExist, "A product with the given SKU does not exist");
            return;
        }

        await _publisher.PublishMessageAsync("integration.product.updated", product);
    }

    public async Task RemoveProductAsync(string sku)
    {
        var entity = await _catalogDbContext.Products.FirstOrDefaultAsync(m => m.Sku == sku);
        if (entity == null)
        {
            _notificationHandler.AddNotification(ProductDoesNotExist, "A product with the given SKU does not exist");
            return;
        }

        await _publisher.PublishMessageAsync("integration.product.removed", new { Sku = sku });
    }
}