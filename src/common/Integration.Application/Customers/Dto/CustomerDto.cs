namespace Integration.Application.Customers.Dto;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Document { get; set; }
}