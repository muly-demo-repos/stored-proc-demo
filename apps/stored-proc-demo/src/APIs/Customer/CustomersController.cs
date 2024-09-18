using Microsoft.AspNetCore.Mvc;

namespace StoredProcDemo.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
