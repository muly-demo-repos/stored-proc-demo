using StoredProcDemo.Infrastructure;

namespace StoredProcDemo.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(StoredProcDemoDbContext context)
        : base(context) { }
}
