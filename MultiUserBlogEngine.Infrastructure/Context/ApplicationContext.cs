using MultiUserBlogEngine.Domain.Dependencies;

namespace MultiUserBlogEngine.Infrastructure.Context;

public class ApplicationContext : IApplicationContext
{
    public int? GetCurrentUserId()
    {
        // todo:
        return 1;
    }
}
