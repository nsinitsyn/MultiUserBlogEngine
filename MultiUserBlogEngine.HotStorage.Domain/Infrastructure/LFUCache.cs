namespace MultiUserBlogEngine.HotStorage.Domain.Infrastructure;

/// <summary>
/// LFU (least frequently used) кеш. Вытесняет значения из кеша, к которым обращаются меньше всего.
/// Ведет учет промахов кеша. Для этого используется внутренний LFU-кеш. 
/// Когда число промахов для ключа K достигает заданного значения, сигнализирует о необходимости добавления значения ключа K.
/// </summary>
internal class LFUCache<TKey, TValue>
    where TKey : notnull
{
    private readonly int _maxElementsCount;
    private readonly Dictionary<TKey, TValue> _cache;
    private readonly Dictionary<int, ReaderWriterLockSlim> _locks;
    private readonly int _locksCount;

    public LFUCache(int maxElementsCount)
    {
        _maxElementsCount = maxElementsCount;
        _cache = new Dictionary<TKey, TValue>(_maxElementsCount);
        _locksCount = _maxElementsCount / 10;
    }

    public void Add(TKey key, TValue value)
    {
        try
        {
            throw new NotImplementedException();
        }
        finally
        {
        }
    }

    public void Update(TKey key, TValue value)
    {
        try
        {
            throw new NotImplementedException();
        }
        finally
        {
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        try
        {
            throw new NotImplementedException();
        }
        finally
        {
        }
    }
}
