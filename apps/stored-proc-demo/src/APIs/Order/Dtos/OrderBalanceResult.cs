using System.ComponentModel.DataAnnotations;

namespace StoredProcDemo.APIs;

public class OrderBalanceResult
{
    [Key()]
    [Required()]
    public double OrderBalance { get; set; }
}
