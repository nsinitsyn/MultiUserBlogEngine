using MultiUserBlogEngine.Domain.Entities.Base;

namespace MultiUserBlogEngine.Domain.Entities;

public class BlockedUser : AuthoredEntity
{
    /// <summary>
    /// Заблокированный пользователь - связь 1:1
    /// </summary>
    public int UserId { get; set; }

    public DateTime? BlockedUntil { get; set; }

    public string? BlockedReasonComment { get; set; }
}
