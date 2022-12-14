namespace Integration.Application.Catalog.Dto;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Sku { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
}