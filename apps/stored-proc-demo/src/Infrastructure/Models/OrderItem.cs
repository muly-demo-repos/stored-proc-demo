using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoredProcDemo.Infrastructure.Models;

[Table("OrderItems")]
public class OrderItemDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public string? OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public OrderDbModel? Order { get; set; } = null;

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    [StringLength(1000)]
    public string? Sku { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
