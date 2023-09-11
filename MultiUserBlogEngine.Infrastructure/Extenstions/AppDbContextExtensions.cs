using Microsoft.EntityFrameworkCore;
using MultiUserBlogEngine.Domain.Entities;
using MultiUserBlogEngine.Domain.Entities.Enum;
using MultiUserBlogEngine.Infrastructure.DbAccess;

namespace MultiUserBlogEngine.Infrastructure.Extenstions;

public static class AppDbContextExtensions
{
    public static void SeedDatabase(this AppDbContext dbContext)
    {
        if(dbContext.Users.Any())
        {
            return;
        }

        dbContext.Users.Add(new User
        {
            UserRole = UserRole.SystemUser,
            Email = "not defined",
            DisplayName = "System"
        });

        dbContext.SaveChanges();
    }
}
