using StoredProcDemo.Infrastructure;

namespace StoredProcDemo.APIs;

public class OrderItemsService : OrderItemsServiceBase
{
    public OrderItemsService(StoredProcDemoDbContext context)
        : base(context) { }
}
