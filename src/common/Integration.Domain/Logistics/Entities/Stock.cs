namespace Integration.Domain.Logistics.Entities;

public class Stock
{
    public Guid Id { get; set; }
    public string? Sku { get; set; }
    public string? CenterCode { get; set; }
    public int Quantity { get; set; }
    
    public virtual Center Center { get; set; }
}