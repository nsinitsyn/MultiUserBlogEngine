using MultiUserBlogEngine.Domain.Entities.Base;
using MultiUserBlogEngine.Domain.Entities.Enum;

namespace MultiUserBlogEngine.Domain.Entities;

public class User : AuthoredEntity
{
    public int Id { get; set; }

    public required string Email { get; set; }

    public required string DisplayName { get; set; }

    public bool EmailConfirmed { get; set; }

    public UserRole UserRole { get; set; }

    public string? PhotoUrl { get; set; }

    public int Rating { get; set; }

    public DateTime? LastAuthorizedDateTime { get; set; }

    public string? LastAuthorizedIpAddress { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDateTime { get; set; }

    /// <summary>
    /// Пользователь, который удалил текущего пользователя.
    /// </summary>
    public int? DeletedUserId { get; set; }

    /// <summary>
    /// Причина удаления, если пользователь был удален модератором.
    /// </summary>
    public string? DeletedReasonComment { get; set; }

    #region Связи

    /// <summary>
    /// Посты пользователя. Связь 1:n.
    /// </summary>
    public ICollection<Post>? Posts { get; set; }

    /// <summary>
    /// Информация о блокировке пользователя. Связь 1:1.
    /// </summary>
    public BlockedUser? BlockingInformation { get; set; }

    /// <summary>
    /// Посты, добавленные пользователем в избранное. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<Post>? FavoritesPosts { get; set; }

    /// <summary>
    /// Посты, добавленные пользователем для чтения позже. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<Post>? ReadLaterPosts { get; set; }

    /// <summary>
    /// Комментарии пользователя. Связь 1:n.
    /// </summary>
    public ICollection<Comment>? Comments { get; set; }

    /// <summary>
    /// Пользователь, который удалил текущего пользователя. Связь 1:n.
    /// </summary>
    public User? DeletedUser { get; set; }

    /// <summary>
    /// Подписчики текущего пользователя. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<User>? Subscribers { get; set; }

    /// <summary>
    /// Пользователи, на которых подписан текущий пользователь. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<User>? SubscribedTo { get; set; }

    /// <summary>
    /// Теги, добавленные текущим пользователем в игнор-лист. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<PostTag>? IgnoredPostTags { get; set; }

    /// <summary>
    /// Авторы постов, добавленные текущим пользователем в игнор-лист. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<User>? IgnoredAuthors { get; set; }

    /// <summary>
    /// Жалобы текущего пользователя на посты. Связь 1:n
    /// </summary>
    public ICollection<PostComplaint>? PostComplaints { get; set; }

    #endregion
}
