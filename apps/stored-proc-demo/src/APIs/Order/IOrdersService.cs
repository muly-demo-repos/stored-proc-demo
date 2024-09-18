using StoredProcDemo.APIs.Common;
using StoredProcDemo.APIs.Dtos;

namespace StoredProcDemo.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Order
    /// </summary>
    public Task<Order> CreateOrder(OrderCreateInput order);

    /// <summary>
    /// Delete one Order
    /// </summary>
    public Task DeleteOrder(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<Order>> Orders(OrderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    public Task<MetadataDto> OrdersMeta(OrderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Order
    /// </summary>
    public Task<Order> Order(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Order
    /// </summary>
    public Task UpdateOrder(OrderWhereUniqueInput uniqueId, OrderUpdateInput updateDto);

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public Task<Customer> GetCustomer(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple OrderItems records to Order
    /// </summary>
    public Task ConnectOrderItems(
        OrderWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Disconnect multiple OrderItems records from Order
    /// </summary>
    public Task DisconnectOrderItems(
        OrderWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Find multiple OrderItems records for Order
    /// </summary>
    public Task<List<OrderItem>> FindOrderItems(
        OrderWhereUniqueInput uniqueId,
        OrderItemFindManyArgs OrderItemFindManyArgs
    );

    /// <summary>
    /// Update multiple OrderItems records for Order
    /// </summary>
    public Task UpdateOrderItems(
        OrderWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Connect multiple Payments records to Order
    /// </summary>
    public Task ConnectPayments(
        OrderWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple Payments records from Order
    /// </summary>
    public Task DisconnectPayments(
        OrderWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Find multiple Payments records for Order
    /// </summary>
    public Task<List<Payment>> FindPayments(
        OrderWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple Payments records for Order
    /// </summary>
    public Task UpdatePayments(
        OrderWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );
    public Task<OrderBalanceResult> SpGetOrderBalance(OrderBalanceArgs orderBalanceArgsDto);
}
