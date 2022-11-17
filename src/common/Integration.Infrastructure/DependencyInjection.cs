using FluentValidation;
using Integration.Application.Catalog.Interfaces;
using Integration.Application.Catalog.Validators;
using Integration.Application.Interfaces;
using Integration.Application.Notifications;
using Integration.Infrastructure.Catalog.Persistence;
using Integration.Infrastructure.Catalog.Services;
using Integration.Infrastructure.Common;
using Integration.Infrastructure.Customers.Persistence;
using Integration.Infrastructure.Logistics.Persistence;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Savorboard.CAP.InMemoryMessageQueue;

namespace Integration.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) => services
        .AddCatalog(configuration)
        .AddCustomers(configuration)
        .AddLogistics(configuration)
        .AddMapster()
        .AddCap()
        .AddValidatorsFromAssemblyContaining(typeof(ProductDtoValidator))
        .AddScoped<IMessagePublisher, CapMessagePublisher>()
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

    private static IServiceCollection AddCap(this IServiceCollection services) => services
        .AddCap(options =>
        {
            options.UseInMemoryStorage();
            options.UseInMemoryMessageQueue();
            options.UseDashboard();
        }).Services;
}