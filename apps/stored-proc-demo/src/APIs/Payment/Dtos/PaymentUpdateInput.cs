namespace StoredProcDemo.APIs.Dtos;

public class PaymentUpdateInput
{
    public string? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Order { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
