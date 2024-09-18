using StoredProcDemo.Infrastructure;

namespace StoredProcDemo.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(StoredProcDemoDbContext context)
        : base(context) { }
}
