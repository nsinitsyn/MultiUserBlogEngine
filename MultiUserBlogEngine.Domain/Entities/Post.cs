using MultiUserBlogEngine.Domain.Entities.Base;

namespace MultiUserBlogEngine.Domain.Entities;

public class Post : AuthoredEntity
{
    public int Id { get; set; }

    public int AuthorUserId { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public required string PreviewContent { get; set; }

    public int Rating { get; set; }

    public bool IsApproved { get; set; }

    public DateTime ApprovedDateTime { get; set; }

    public bool IsHidden { get; set; }

    public DateTime HiddenDateTime { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDateTime { get; set; }

    /// <summary>
    /// Пользователь, который удалил пост.
    /// </summary>
    public int? DeletedUserId { get; set; }

    /// <summary>
    /// Причина удаления, если пост был удален модератором.
    /// </summary>
    public string? DeletedReasonComment { get; set; }

    #region Связи

    /// <summary>
    /// Автор поста. Связь 1:n.
    /// </summary>
    public User? AuthorUser { get; set; }

    /// <summary>
    /// Комментарии к посту. Связь 1:n.
    /// </summary>
    public ICollection<Comment>? Comments { get; set; }

    /// <summary>
    /// Теги к посту. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<Tag>? Tags { get; set; }

    /// <summary>
    /// Пользователь, который удалил пост. Связь 1:n.
    /// </summary>
    public User? DeletedUser { get; set; }

    /// <summary>
    /// Неуникальные просмотры текущего поста. Связь 1:1.
    /// </summary>
    public PostViews? Views { get; set; }

    /// <summary>
    /// Уникальные просмотры текущего поста зарегистрированными пользователями. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<User>? UserViews { get; set; }

    /// <summary>
    /// Уникальные просмотры текущего поста незарегистрированными пользователями. Связь 1:n.
    /// </summary>
    public ICollection<PostGuestUserView>? GuestUserViews { get; set; }

    /// <summary>
    /// Лайки и дизлайки поста. Связь 1:n.
    /// </summary>
    public ICollection<PostReaction>? Reactions { get; set; }

    #endregion
}
