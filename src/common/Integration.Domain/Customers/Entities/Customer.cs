namespace Integration.Domain.Customers.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Document { get; set; }
}