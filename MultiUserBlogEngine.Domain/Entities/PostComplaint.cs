using MultiUserBlogEngine.Domain.Entities.Base;
using MultiUserBlogEngine.Domain.Entities.Enum;

namespace MultiUserBlogEngine.Domain.Entities;

/// <summary>
/// Жалоба пользователя на пост.
/// </summary>
public class PostComplaint : AuthoredEntity
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// Текст жалобы.
    /// </summary>
    public required string ComplaintText { get; set; }

    public PostComplaintStatus PostComplaintStatus { get; set; }

    /// <summary>
    /// Пользователь, назначенный на рассмотрение жалобы.
    /// </summary>
    public int? AppointedUserId { get; set; }

    /// <summary>
    /// Комментарий назначенного на рассмотрение пользователя, оставленный по результу рассмотрения жалобы.
    /// </summary>
    public string? AppointedUserProcessedStatusComment { get; set; }

    #region Связи

    /// <summary>
    /// Пост, на который оставлена жалоба. Связь 1:n.
    /// </summary>
    public Post? Post { get; set; }

    /// <summary>
    /// Пользователь, оставивший жалобу. Связь 1:n.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Пользователь, назначенный на рассмотрение жалобы.
    /// </summary>
    public User? AppointedUser { get; set; }

    #endregion
}
