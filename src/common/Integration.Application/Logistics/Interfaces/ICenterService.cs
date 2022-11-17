using System.Linq.Expressions;
using Integration.Application.Logistics.Dto;
using Integration.Domain.Logistics.Entities;

namespace Integration.Application.Logistics.Interfaces;

public interface ICenterService
{
    Task<CenterDto?> GetCenterByIdAsync(Guid id);
    Task<CenterDto?> GetCenterByCodeAsync(string code);
    Task<IList<CenterDto>> GetCentersAsync(Expression<Func<Center, bool>> filter, int pageIndex, int pageSize);
    Task AddCenterAsync(CenterDto center);
    Task UpdateCenterAsync(CenterDto center);
    Task RemoveCenterAsync(string code);
}