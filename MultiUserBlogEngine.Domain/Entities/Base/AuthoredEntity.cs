namespace MultiUserBlogEngine.Domain.Entities.Base;

public abstract class AuthoredEntity
{
    public int CreatedUserId { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public int LastUpdatedUserId { get; set; }

    public DateTime LastUpdatedDateTime { get; set; }
}
