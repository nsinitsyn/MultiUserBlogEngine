namespace MultiUserBlogEngine.Domain.Entities;

/// <summary>
/// Неуникальные просмотры постов. Вынесено в отдельную сущность из-за высокой частоты изменения числа просмотров, 
/// чтобы не блокировать обновление всей сущности поста.
/// </summary>
public class PostViews
{
    public int PostId { get; set; }

    /// <summary>
    /// Число неуникальных просмотров текущего поста.
    /// </summary>
    public int ViewsNumber { get; set; }

    #region Связи

    /// <summary>
    /// Пост, за которым ведется число просмотров. Связь 1:1.
    /// </summary>
    public Post? Post { get; set; }

    #endregion
}
