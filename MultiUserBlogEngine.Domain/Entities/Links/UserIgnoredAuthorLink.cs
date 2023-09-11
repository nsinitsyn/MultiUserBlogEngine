namespace MultiUserBlogEngine.Domain.Entities.Links;

/// <summary>
/// Связующая сущность для связи пользователей и игнорируемых им пользователей (User-User, многие-ко-многим). 
/// Объявлена явно, т.к. EF Core не умеет создавать неявную сущность для связи многие-ко-многим, если на обоих концах связи одна и та же сущность.
/// </summary>
public class UserIgnoredAuthorLink
{
    public int UserId { get; set; }

    public int IgnoredAuthorUserId { get; set; }

    public User? User { get; set; }

    public User? IgnoredAuthorUser { get; set; }
}
