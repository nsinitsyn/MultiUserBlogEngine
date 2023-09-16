namespace MultiUserBlogEngine.HotStorage.Domain.Entities;

public class PostPreview
{
    public required int Id { get; set; }

    public required string Title { get; set; }

    public required string PreviewContent { get; set; }

    public required string PostLink { get; set; }

    public required int Rating { get; set; }

    public required DateTime CreatedDateTime { get; set; }

    public required int Version { get; set; }
}
