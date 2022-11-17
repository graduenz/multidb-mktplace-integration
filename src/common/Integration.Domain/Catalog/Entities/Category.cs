namespace Integration.Domain.Catalog.Entities;

public class Category
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public string? Name { get; set; }
}