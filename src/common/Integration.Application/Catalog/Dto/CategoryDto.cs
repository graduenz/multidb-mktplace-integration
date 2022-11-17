namespace Integration.Application.Catalog.Dto;

public class CategoryDto
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public string? Name { get; set; }
}