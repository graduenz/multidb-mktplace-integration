using Integration.Application.Catalog.Dto;

namespace Integration.Application.Catalog.Interfaces;

public interface ICategoryService
{
    Task<IList<CategoryDto>> GetAllCategoriesAsync();
}