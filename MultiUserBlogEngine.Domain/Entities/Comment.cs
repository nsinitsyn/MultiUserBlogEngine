using MultiUserBlogEngine.Domain.Entities.Base;

namespace MultiUserBlogEngine.Domain.Entities;

public class Comment : AuthoredEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PostId {  get; set; }

    public required string Content { get; set; }

    /// <summary>
    /// Комментарий, ответом на который является текущий комментарий.
    /// </summary>
    public int? ParentCommentId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDateTime { get; set; }

    /// <summary>
    /// Пользователь, который удалил комментарий.
    /// </summary>
    public int? DeletedUserId { get; set; }

    /// <summary>
    /// Причина удаления, если комментарий был удален модератором.
    /// </summary>
    public string? DeletedReasonComment { get; set; }

    #region Связи

    /// <summary>
    /// Пользователь, оставивший комментарий. Связь 1:n.
    /// </summary>
    public required User User { get; set; }

    /// <summary>
    /// Пост, к которому оставлен комментарий. Связь 1:n.
    /// </summary>
    public required Post Post { get; set; }

    /// <summary>
    /// Комментарий, ответом на который является текущий комментарий. Связь 1:n.
    /// </summary>
    public Comment? ParentComment { get; set; }

    /// <summary>
    /// Ответы на текущий комментарий. Связь 1:n.
    /// </summary>
    public required ICollection<Comment> ChildComments { get; set; }

    /// <summary>
    /// Пользователь, который удалил комментарий. Связь 1:n.
    /// </summary>
    public User? DeletedUser { get; set; }

    /// <summary>
    /// Лайки и дизлайки комментария. Связь 1:n.
    /// </summary>
    public required ICollection<CommentReaction> Reactions { get; set; }

    #endregion
}
