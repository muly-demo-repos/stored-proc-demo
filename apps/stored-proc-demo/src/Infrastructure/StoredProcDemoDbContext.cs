using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcDemo.APIs;
using StoredProcDemo.Infrastructure.Models;

namespace StoredProcDemo.Infrastructure;

public class StoredProcDemoDbContext : IdentityDbContext<IdentityUser>
{
    public StoredProcDemoDbContext(DbContextOptions<StoredProcDemoDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<OrderItemDbModel> OrderItems { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }
    public DbSet<OrderBalanceResult> OrderBalances { get; set; }

    public async Task<decimal?> GetOrderBalance(string orderId)
    {
        var parameter = new SqlParameter("@OrderId", orderId);
        Console.WriteLine($"Calling stored procedure spGetOrderBalance with parameter {orderId}");

        // Call stored procedure and return the result
        // Fetch the result from the stored procedure without further composing
        var result = await this
            .OrderBalances.FromSqlInterpolated($"EXEC spGetOrderBalance @OrderId={parameter}")
            .ToListAsync(); // Fetch the result set as a list (async)

        // Use FirstOrDefault() to get the first result after fetching the data
        var output = result.FirstOrDefault()?.OrderBalance;
        Console.WriteLine($"Stored procedure spGetOrderBalance returned {output}");
        return (decimal?)output;
    }
}
