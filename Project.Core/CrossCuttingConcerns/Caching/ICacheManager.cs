using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        bool IsAdd(string key);
        void Add(string key, object data, int cacheTime);
        void Remove(string key);
        void Clear();
        void RemoveByPattern(string pattern);

    }
}
