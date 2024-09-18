using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoredProcDemo.Infrastructure.Models;

[Table("Payments")]
public class PaymentDbModel
{
    [StringLength(1000)]
    public string? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public OrderDbModel? Order { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
