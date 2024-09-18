using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StoredProcDemo.Infrastructure;
using StoredProcDemo.Infrastructure.Models;

namespace StoredProcDemo;

public class SeedDevelopmentData
{
    public static async Task SeedDevUser(
        IServiceProvider serviceProvider,
        IConfiguration configuration
    )
    {
        var context = serviceProvider.GetRequiredService<StoredProcDemoDbContext>();
        var userStore = new UserStore<IdentityUser>(context);
        var usernameValue = "test@email.com";
        var passwordValue = "P@ssw0rd!";

        var existingUser = await userStore.FindByEmailAsync(usernameValue);
        if (existingUser != null)
        {
            return;
        }

        var user = new IdentityUser
        {
            Email = usernameValue,
            UserName = usernameValue,
            NormalizedUserName = usernameValue.ToUpperInvariant(),
            NormalizedEmail = usernameValue.ToUpperInvariant(),
        };
        var password = new PasswordHasher<IdentityUser>();
        var hashed = password.HashPassword(user, passwordValue);
        user.PasswordHash = hashed;
        await userStore.CreateAsync(user);

        var amplicationRoles = configuration
            .GetSection("AmplicationRoles")
            .AsEnumerable()
            .Where(x => x.Value != null)
            .Select(x => x.Value.ToString())
            .ToArray();
        var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in amplicationRoles)
        {
            await userStore.AddToRoleAsync(user, _roleManager.NormalizeKey(role));
        }

        await context.SaveChangesAsync();
    }
}
