namespace MultiUserBlogEngine.Domain.Entities;

public class Tag
{
    public required string Id { get; set; }

    #region Связи

    /// <summary>
    /// Посты, помеченные текущим тегом. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<Post>? Posts { get; set; }

    #endregion
}
