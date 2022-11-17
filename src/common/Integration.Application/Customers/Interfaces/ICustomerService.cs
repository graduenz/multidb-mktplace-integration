using System.Linq.Expressions;
using Integration.Application.Customers.Dto;
using Integration.Domain.Customers.Entities;

namespace Integration.Application.Customers.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto?> GetCustomerByIdAsync(Guid id);
    Task<CustomerDto?> GetCustomerByCodeAsync(string code);
    Task<IList<CustomerDto>> GetCustomersAsync(Expression<Func<Customer, bool>> filter, int pageIndex, int pageSize);
    Task AddCustomerAsync(CustomerDto customer);
    Task UpdateCustomerAsync(CustomerDto customer);
    Task RemoveCustomerAsync(string code);
}