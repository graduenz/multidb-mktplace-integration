using Integration.Application.Catalog.Dto;
using Integration.Application.Catalog.Interfaces;
using Integration.Infrastructure.Catalog.Persistence;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Integration.Infrastructure.Catalog.Services;

public class CategoryService : ICategoryService
{
    private readonly CatalogDbContext _catalogDbContext;
    private readonly IMapper _mapper;

    public CategoryService(CatalogDbContext catalogDbContext, IMapper mapper)
    {
        _catalogDbContext = catalogDbContext;
        _mapper = mapper;
    }
    
    public async Task<IList<CategoryDto>> GetAllCategoriesAsync() =>
        await _catalogDbContext.Categories.Select(entity => _mapper.Map<CategoryDto>(entity)).ToListAsync();
}