using System.ComponentModel.DataAnnotations;

namespace StoredProcDemo.APIs;

public class OrderBalanceResult
{
    [Required()]
    public double OrderBalance { get; set; }
}
