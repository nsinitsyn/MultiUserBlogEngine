namespace MultiUserBlogEngine.Domain.Entities;

public class PostReaction
{
    public int PostId { get; set; }

    public int UserId {  get; set; }

    public bool IsLike { get; set; }

    public DateTime CreatedDateTime { get; set; }

    #region Связи

    public Post? Post { get; set; }

    public User? User { get; set; }

    #endregion
}
