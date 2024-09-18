using Microsoft.AspNetCore.Mvc;
using StoredProcDemo.APIs.Common;
using StoredProcDemo.Infrastructure.Models;

namespace StoredProcDemo.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PaymentFindManyArgs : FindManyInput<Payment, PaymentWhereInput> { }
