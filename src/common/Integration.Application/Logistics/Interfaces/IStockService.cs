using System.Linq.Expressions;
using Integration.Application.Logistics.Dto;
using Integration.Domain.Logistics.Entities;

namespace Integration.Application.Logistics.Interfaces;

public interface IStockService
{
    Task<StockDto?> GetStockByIdAsync(Guid id);
    Task<IList<StockDto>> GetStocksAsync(Expression<Func<Stock, bool>> filter, int pageIndex, int pageSize);
    Task AddStockAsync(StockDto stock);
    Task UpdateStockAsync(StockDto stock);
    Task RemoveStockAsync(string code);
}