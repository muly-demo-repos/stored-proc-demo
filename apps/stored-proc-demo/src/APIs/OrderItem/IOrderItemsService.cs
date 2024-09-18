using StoredProcDemo.APIs.Common;
using StoredProcDemo.APIs.Dtos;

namespace StoredProcDemo.APIs;

public interface IOrderItemsService
{
    /// <summary>
    /// Create one OrderItem
    /// </summary>
    public Task<OrderItem> CreateOrderItem(OrderItemCreateInput orderitem);

    /// <summary>
    /// Delete one OrderItem
    /// </summary>
    public Task DeleteOrderItem(OrderItemWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many OrderItems
    /// </summary>
    public Task<List<OrderItem>> OrderItems(OrderItemFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about OrderItem records
    /// </summary>
    public Task<MetadataDto> OrderItemsMeta(OrderItemFindManyArgs findManyArgs);

    /// <summary>
    /// Get one OrderItem
    /// </summary>
    public Task<OrderItem> OrderItem(OrderItemWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one OrderItem
    /// </summary>
    public Task UpdateOrderItem(OrderItemWhereUniqueInput uniqueId, OrderItemUpdateInput updateDto);

    /// <summary>
    /// Get a Order record for OrderItem
    /// </summary>
    public Task<Order> GetOrder(OrderItemWhereUniqueInput uniqueId);
}
