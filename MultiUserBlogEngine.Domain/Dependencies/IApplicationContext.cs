namespace MultiUserBlogEngine.Domain.Dependencies;

public interface IApplicationContext
{
    int? GetCurrentUserId();
}
