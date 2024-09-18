using System.ComponentModel.DataAnnotations;

namespace StoredProcDemo.APIs;

public class OrderBalanceArgs
{
    [Required()]
    public string OrderId { get; set; }
}
