namespace Integration.Application.Logistics.Dto;

public class StockDto
{
    public Guid Id { get; set; }
    public string? Sku { get; set; }
    public string? CenterCode { get; set; }
    public int Quantity { get; set; }
}