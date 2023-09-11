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

        if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MULTI_USER_BLOG_ENGINE_SEED_TEST_DATA")))
        {
            SeedTestData(dbContext);
        }

        dbContext.SaveChanges();
    }

    private static void SeedTestData(AppDbContext dbContext)
    {
        dbContext.Users.Add(new User
        {
            UserRole = UserRole.User,
            Email = "user@user.com",
            DisplayName = "User1"
        });
    }
}
