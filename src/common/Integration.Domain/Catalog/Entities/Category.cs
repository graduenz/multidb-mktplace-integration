namespace Integration.Domain.Catalog.Entities;

public class Category
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public string? Name { get; set; }
    
    public virtual IList<Product>? Products { get; set; }
    public virtual IList<Category>? Children { get; set; }
    public virtual Category? Parent { get; set; }
}