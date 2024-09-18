using StoredProcDemo.Infrastructure;

namespace StoredProcDemo.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(StoredProcDemoDbContext context)
        : base(context) { }
}
