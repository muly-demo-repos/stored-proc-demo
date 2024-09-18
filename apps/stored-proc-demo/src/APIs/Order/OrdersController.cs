using Microsoft.AspNetCore.Mvc;

namespace StoredProcDemo.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
