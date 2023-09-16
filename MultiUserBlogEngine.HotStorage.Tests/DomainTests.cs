using MultiUserBlogEngine.HotStorage.Domain.Entities;

namespace MultiUserBlogEngine.HotStorage.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var hotStorage = new Domain.HotStorage();

        var utcNow = DateTime.UtcNow;

        hotStorage.AddPostToLastAdded(new PostPreview
        {
            Id = 1,
            Title = "Test1",
            PreviewContent = "Test1",
            CreatedDateTime = utcNow.AddSeconds(5),
            PostLink = "Test1",
            Rating = 0,
            Version = 1
        });

        hotStorage.AddPostToLastAdded(new PostPreview
        {
            Id = 2,
            Title = "Test2",
            PreviewContent = "Test2",
            CreatedDateTime = utcNow,
            PostLink = "Test2",
            Rating = 0,
            Version = 1
        });

        hotStorage.AddPostToLastAdded(new PostPreview
        {
            Id = 3,
            Title = "Test3",
            PreviewContent = "Test3",
            CreatedDateTime = utcNow.AddSeconds(15),
            PostLink = "Test3",
            Rating = 0,
            Version = 1
        });

        var posts = hotStorage.GetLastAddedPosts(10, 0);

        CollectionAssert.AreEqual(new List<int> { 3, 1, 2 }, posts.Select(x => x.Id));
    }

    [Test]
    public void Test2()
    {
        var hotStorage = new Domain.HotStorage();

        var utcNow = DateTime.UtcNow;

        ManualResetEventSlim _waitHandle = new ManualResetEventSlim(false);

        var tasks = new List<Task>
        {
            Task.Run(() =>
            {
                _waitHandle.Wait();
                hotStorage.AddPostToMostPopular(new PostPreview
                {
                    Id = 1,
                    Title = "Test1",
                    PreviewContent = "Test1",
                    CreatedDateTime = utcNow.AddSeconds(5),
                    PostLink = "Test1",
                    Rating = 10,
                    Version = 1
                });
            }),

            Task.Run(() =>
            {
                _waitHandle.Wait();
                hotStorage.AddPostToMostPopular(new PostPreview
                {
                    Id = 2,
                    Title = "Test1",
                    PreviewContent = "Test1",
                    CreatedDateTime = utcNow.AddSeconds(5),
                    PostLink = "Test1",
                    Rating = 0,
                    Version = 1
                });
            }),

            Task.Run(() =>
            {
                _waitHandle.Wait();
                hotStorage.AddPostToMostPopular(new PostPreview
                {
                    Id = 3,
                    Title = "Test1",
                    PreviewContent = "Test1",
                    CreatedDateTime = utcNow.AddSeconds(5),
                    PostLink = "Test1",
                    Rating = 15,
                    Version = 1
                });
            }),

            Task.Run(() =>
            {
                _waitHandle.Wait();
                hotStorage.AddPostToMostPopular(new PostPreview
                {
                    Id = 4,
                    Title = "Test1",
                    PreviewContent = "Test1",
                    CreatedDateTime = utcNow.AddSeconds(5),
                    PostLink = "Test1",
                    Rating = 100,
                    Version = 1
                });
            }),

            Task.Run(() =>
            {
                _waitHandle.Wait();
                hotStorage.AddPostToMostPopular(new PostPreview
                {
                    Id = 5,
                    Title = "Test1",
                    PreviewContent = "Test1",
                    CreatedDateTime = utcNow.AddSeconds(5),
                    PostLink = "Test1",
                    Rating = 20,
                    Version = 1
                });
            })
        };

        _waitHandle.Set();

        Task.WaitAll(tasks.ToArray());

        var posts = hotStorage.GetMostPopularPosts(10, 0);

        CollectionAssert.AreEqual(new List<int> { 100, 20, 15, 10, 0 }, posts.Select(x => x.Rating));
    }
}