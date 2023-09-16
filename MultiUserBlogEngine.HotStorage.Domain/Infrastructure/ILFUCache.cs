using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBlogEngine.HotStorage.Domain.Infrastructure;

internal interface ILFUCache<TKey, TValue>
{
    void Add(TKey key, TValue value);

    bool TryGetValue(TKey key, out TValue value);
}
