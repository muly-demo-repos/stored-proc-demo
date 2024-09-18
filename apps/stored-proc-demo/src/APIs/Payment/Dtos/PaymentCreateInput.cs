namespace StoredProcDemo.APIs.Dtos;

public class PaymentCreateInput
{
    public string? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public Order? Order { get; set; }

    public DateTime UpdatedAt { get; set; }
}
