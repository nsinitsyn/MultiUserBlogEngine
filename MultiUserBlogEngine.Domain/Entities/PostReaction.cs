namespace MultiUserBlogEngine.Domain.Entities;

public class PostReaction
{
    public int PostId { get; set; }

    public int UserId {  get; set; }

    public bool IsLike { get; set; }

    public DateTime CreatedDateTime { get; set; }
}
