using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoredProcDemo.APIs;
using StoredProcDemo.APIs.Common;
using StoredProcDemo.APIs.Dtos;
using StoredProcDemo.APIs.Errors;

namespace StoredProcDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrdersControllerBase : ControllerBase
{
    protected readonly IOrdersService _service;

    public OrdersControllerBase(IOrdersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Order
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Order>> CreateOrder(OrderCreateInput input)
    {
        var order = await _service.CreateOrder(input);

        return CreatedAtAction(nameof(Order), new { id = order.Id }, order);
    }

    /// <summary>
    /// Delete one Order
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteOrder([FromRoute()] OrderWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Order>>> Orders([FromQuery()] OrderFindManyArgs filter)
    {
        return Ok(await _service.Orders(filter));
    }

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OrdersMeta([FromQuery()] OrderFindManyArgs filter)
    {
        return Ok(await _service.OrdersMeta(filter));
    }

    /// <summary>
    /// Get one Order
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Order>> Order([FromRoute()] OrderWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Order(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Order
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateOrder(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromQuery()] OrderUpdateInput orderUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrder(uniqueId, orderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    [HttpGet("{Id}/customer")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] OrderWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }

    /// <summary>
    /// Connect multiple OrderItems records to Order
    /// </summary>
    [HttpPost("{Id}/orderItems")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectOrderItems(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromQuery()] OrderItemWhereUniqueInput[] orderItemsId
    )
    {
        try
        {
            await _service.ConnectOrderItems(uniqueId, orderItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple OrderItems records from Order
    /// </summary>
    [HttpDelete("{Id}/orderItems")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectOrderItems(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromBody()] OrderItemWhereUniqueInput[] orderItemsId
    )
    {
        try
        {
            await _service.DisconnectOrderItems(uniqueId, orderItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple OrderItems records for Order
    /// </summary>
    [HttpGet("{Id}/orderItems")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<OrderItem>>> FindOrderItems(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromQuery()] OrderItemFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindOrderItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple OrderItems records for Order
    /// </summary>
    [HttpPatch("{Id}/orderItems")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateOrderItems(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromBody()] OrderItemWhereUniqueInput[] orderItemsId
    )
    {
        try
        {
            await _service.UpdateOrderItems(uniqueId, orderItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Payments records to Order
    /// </summary>
    [HttpPost("{Id}/payments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectPayments(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromQuery()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.ConnectPayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Payments records from Order
    /// </summary>
    [HttpDelete("{Id}/payments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectPayments(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.DisconnectPayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Payments records for Order
    /// </summary>
    [HttpGet("{Id}/payments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Payment>>> FindPayments(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromQuery()] PaymentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayments(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Payments records for Order
    /// </summary>
    [HttpPatch("{Id}/payments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdatePayments(
        [FromRoute()] OrderWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.UpdatePayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("sp-get-order-balance")]
    [Authorize(Roles = "user")]
    public async Task<OrderBalanceResult> SpGetOrderBalance(
        [FromBody()] OrderBalanceArgs orderBalanceArgsDto
    )
    {
        return await _service.SpGetOrderBalance(orderBalanceArgsDto);
    }
}
