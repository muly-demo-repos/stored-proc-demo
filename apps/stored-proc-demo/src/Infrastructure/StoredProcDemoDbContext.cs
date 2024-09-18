using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
}
