namespace StoredProcDemo.APIs.Dtos;

public class OrderItemCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public Order? Order { get; set; }

    public double? Price { get; set; }

    public string? Sku { get; set; }

    public DateTime UpdatedAt { get; set; }
}
