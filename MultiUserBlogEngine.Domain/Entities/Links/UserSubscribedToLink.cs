namespace MultiUserBlogEngine.Domain.Entities.Links;

/// <summary>
/// Связующая сущность для связи пользователей и пользователей, на которых он подписан (User-User, многие-ко-многим). 
/// Объявлена явно, т.к. EF Core не умеет создавать неявную сущность для связи многие-ко-многим, если на обоих концах связи одна и та же сущность.
/// </summary>
public class UserSubscribedToLink
{
    public int UserId { get; set; }

    public int SubscribedToUserId { get; set; }

    public User? User { get; set; }

    public User? SubscribedToUser { get; set; }
}
