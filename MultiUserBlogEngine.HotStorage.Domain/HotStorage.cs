using MultiUserBlogEngine.HotStorage.Domain.Comparers;
using MultiUserBlogEngine.HotStorage.Domain.Entities;
using MultiUserBlogEngine.HotStorage.Domain.Infrastructure;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MultiUserBlogEngine.HotStorage.Tests")]

namespace MultiUserBlogEngine.HotStorage.Domain;

internal class HotStorage
{
    private const int PostPreviewsLimit = 1000;

    private readonly SortedDictionary<int, PostPreview> _lastAddedPosts; // Последние добавленные 1000 постов
    private readonly SortedDictionary<int, PostPreview> _mostPopularPosts; // Самые популярные 1000 постов за сутки
    // todo: самые популярные 1000 постов за все время?
    private readonly LFUCache<int, Post> _mostViewedPostsWithComments; // 100 самых часто просматриваемых постов на текущий момент

    // Используется для сортировки _lastAddedPosts по нужным полям, а не по ключу (как по умолчанию)
    private readonly Dictionary<int, PostPreview> _lastAddedPostsUnsortable;

    // Используется для сортировки _lastAddedPosts по нужным полям, а не по ключу (как по умолчанию)
    private readonly Dictionary<int, PostPreview> _mostPopularPostsUnsortable;

    private ReaderWriterLockSlim _lastAddedPostsLocker;
    private ReaderWriterLockSlim _mostPopularPostsLocker;

    public HotStorage()
    {
        _lastAddedPostsUnsortable = new Dictionary<int, PostPreview>(PostPreviewsLimit);
        _mostPopularPostsUnsortable = new Dictionary<int, PostPreview>(PostPreviewsLimit);

        _lastAddedPosts = new SortedDictionary<int, PostPreview>(new PostsComparerByCreatedDateTime(_lastAddedPostsUnsortable));
        _mostPopularPosts = new SortedDictionary<int, PostPreview>(new PostsComparerByRating(_mostPopularPostsUnsortable));
        _mostViewedPostsWithComments = new LFUCache<int, Post>(100);

        _lastAddedPostsLocker = new ReaderWriterLockSlim();
        _mostPopularPostsLocker = new ReaderWriterLockSlim();
    }

    public List<PostPreview> GetLastAddedPosts(int count, int skip)
    {
        if (count + skip > PostPreviewsLimit)
        {
            // todo: обращение к main
            throw new NotImplementedException();
        }

        _lastAddedPostsLocker.EnterReadLock();

        try
        {
            return _lastAddedPosts.Skip(skip).Take(count).Select(x => x.Value).ToList();
        }
        finally
        {
            _lastAddedPostsLocker.ExitReadLock();
        }
    }

    public List<PostPreview> GetMostPopularPosts(int count, int skip)
    {
        if (count + skip > PostPreviewsLimit)
        {
            // todo: обращение к main
            throw new NotImplementedException();
        }

        _mostPopularPostsLocker.EnterReadLock();

        try
        {
            return _mostPopularPosts.Skip(skip).Take(count).Select(x => x.Value).ToList();
        }
        finally
        {
            _mostPopularPostsLocker.ExitReadLock();
        }
    }

    public Post GetPostWithComments(int postId)
    {
        if (_mostViewedPostsWithComments.TryGetValue(postId, out var post))
        {
            return post;
        }

        // todo: промах кеша - обращение к main
        throw new NotImplementedException();
    }

    public void AddPostToLastAdded(PostPreview postPreview)
    {
        _lastAddedPostsLocker.EnterWriteLock();

        try
        {
            if (_lastAddedPostsUnsortable.TryGetValue(postPreview.Id, out PostPreview? post) && post.Version > postPreview.Version)
            {
                return;
            }

            if (_lastAddedPosts.Count > PostPreviewsLimit)
            {
                PostPreview lastPost = _lastAddedPosts.Last().Value;
                _lastAddedPosts.Remove(lastPost.Id);
                _lastAddedPostsUnsortable.Remove(lastPost.Id);
            }

            _lastAddedPostsUnsortable[postPreview.Id] = postPreview;
            _lastAddedPosts.Add(postPreview.Id, postPreview);
        }
        finally
        {
            _lastAddedPostsLocker.ExitWriteLock();
        }
    }

    // todo: по какой логике main будет вызывать этот метод?
    public void AddPostToMostPopular(PostPreview postPreview)
    {
        _mostPopularPostsLocker.EnterWriteLock();

        try
        {
            if (_mostPopularPostsUnsortable.TryGetValue(postPreview.Id, out PostPreview? post) && post.Version > postPreview.Version)
            {
                return;
            }

            if (_mostPopularPosts.Count > PostPreviewsLimit)
            {
                PostPreview lastPost = _mostPopularPosts.Last().Value;
                _mostPopularPosts.Remove(lastPost.Id);
                _mostPopularPostsUnsortable.Remove(lastPost.Id);
            }

            _mostPopularPostsUnsortable[postPreview.Id] = postPreview;
            _mostPopularPosts.Add(postPreview.Id, postPreview);
        }
        finally
        {
            _mostPopularPostsLocker.ExitWriteLock();
        }
    }

    public void RemovePost(int postId)
    {
        _lastAddedPostsLocker.EnterUpgradeableReadLock();

        try
        {
            if (_lastAddedPostsUnsortable.TryGetValue(postId, out _))
            {
                _lastAddedPostsLocker.EnterWriteLock();

                try
                {
                    _lastAddedPosts.Remove(postId);
                    _lastAddedPostsUnsortable.Remove(postId);
                }
                finally
                {
                    _lastAddedPostsLocker.ExitWriteLock();
                }
            }
        }
        finally
        {
            _lastAddedPostsLocker.ExitUpgradeableReadLock();
        }

        _mostPopularPostsLocker.EnterUpgradeableReadLock();

        try
        {
            if (_lastAddedPostsUnsortable.TryGetValue(postId, out _))
            {
                _mostPopularPostsLocker.EnterWriteLock();

                try
                {
                    _mostPopularPosts.Remove(postId);
                    _mostPopularPostsUnsortable.Remove(postId);
                }
                finally
                {
                    _mostPopularPostsLocker.ExitWriteLock();
                }
            }
        }
        finally
        {
            _mostPopularPostsLocker.ExitUpgradeableReadLock();
        }
    }

    public void UpdatePostPreview(PostPreview postPreview)
    {

    }
}
