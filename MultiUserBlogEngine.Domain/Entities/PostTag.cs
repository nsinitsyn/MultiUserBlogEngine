namespace MultiUserBlogEngine.Domain.Entities;

public class PostTag
{
    public required string Id { get; set; }

    #region Связи

    /// <summary>
    /// Посты, помеченные текущим тегом. Связь n:n, без связующей сущности.
    /// </summary>
    public ICollection<PostTag>? Posts { get; set; }

    #endregion
}
