namespace MultiUserBlogEngine.Domain.Entities;

public class CommentReaction
{
    public int CommentId { get; set; }

    public int UserId { get; set; }

    public bool IsLike { get; set; }

    public DateTime CreatedDateTime { get; set; }

    #region Связи

    public User? User { get; set; }

    #endregion
}
