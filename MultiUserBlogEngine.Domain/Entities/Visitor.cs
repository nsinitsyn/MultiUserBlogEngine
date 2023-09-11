namespace MultiUserBlogEngine.Domain.Entities;

/// <summary>
/// Информация о посещении сайта.
/// </summary>
public class Visitor
{
    public int Id { get; set; }

    /// <summary>
    /// Пользователь. Поле равно null, если пользователь незарегистрирован.
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// Id сессии, под которой находился пользователь.
    /// </summary>
    public Guid SessionId { get; set; }

    public DateTime EntryDateTime { get; set; }

    public DateTime ExitDateTime { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public string? Platform { get; set; }

    public string? Device { get; set; }

    #region Связи

    /// <summary>
    /// Пользователь. Поле равно null, если посетитель незарегистрирован.
    /// </summary>
    public User? User { get; set; }

    #endregion
}
