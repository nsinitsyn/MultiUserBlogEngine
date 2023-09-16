using MultiUserBlogEngine.HotStorage.Domain.Entities;

namespace MultiUserBlogEngine.HotStorage.Domain.Comparers;

internal class PostsComparerByRating : IComparer<int>
{
    private readonly Dictionary<int, PostPreview> _posts;

    public PostsComparerByRating(Dictionary<int, PostPreview> posts)
    {
        _posts = posts;
    }

    public int Compare(int key1, int key2)
    {
        PostPreview post1 = _posts[key1];
        PostPreview post2 = _posts[key2];

        return post2.Rating.CompareTo(post1.Rating);
    }
}
