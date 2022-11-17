namespace Integration.Domain.Logistics.Entities;

public class Center
{
    public Guid Id { get; set; }
    public string? CenterCode { get; set; }
    public string? LegalName { get; set; }
    public string? Address { get; set; }
}