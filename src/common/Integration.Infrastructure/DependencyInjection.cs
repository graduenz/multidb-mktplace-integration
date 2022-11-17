using FluentValidation;
using Integration.Application.Catalog.Interfaces;
using Integration.Application.Catalog.Validators;
using Integration.Application.Notifications;
using Integration.Infrastructure.Catalog.Persistence;
using Integration.Infrastructure.Catalog.Services;
using Integration.Infrastructure.Customers.Persistence;
using Integration.Infrastructure.Logistics.Persistence;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) => services
        .AddCatalog(configuration)
        .AddCustomers(configuration)
        .AddLogistics(configuration)
        .AddMapster()
        .AddValidatorsFromAssemblyContaining(typeof(ProductDtoValidator))
        .AddScoped<NotificationHandler>();

    private static IServiceCollection AddCatalog(this IServiceCollection services, IConfiguration configuration) => services
        .AddScoped<ICategoryService, CategoryService>()
        .AddScoped<IProductService, ProductService>()
        .AddDbContext<CatalogDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("CatalogDbContext")));

    private static IServiceCollection AddCustomers(this IServiceCollection services, IConfiguration configuration) => services
        //.AddScoped<ICustomerService, CustomerService>()
        .AddDbContext<CustomersDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("CustomersDbContext")));

    private static IServiceCollection AddLogistics(this IServiceCollection services, IConfiguration configuration) => services
        //.AddScoped<ICenterService, CenterService>()
        //.AddScoped<IStockService, StockService>()
        .AddDbContext<LogisticsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("LogisticsDbContext")));

    private static IServiceCollection AddMapster(this IServiceCollection services) => services
        .AddSingleton(TypeAdapterConfig.GlobalSettings)
        .AddScoped<IMapper, ServiceMapper>();
}