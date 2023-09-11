namespace MultiUserBlogEngine.Domain.Entities;

/// <summary>
/// Просмотры постов незарегистрированными пользователями.
/// </summary>
public class PostGuestUserView
{
    public int PostId { get; set; }

    public string? IpAddress { get; set; }
}
