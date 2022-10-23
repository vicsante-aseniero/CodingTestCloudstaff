using System;
using System.Collections.Generic;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// Interface that implements the methods for the cache
    /// allows the test harness to switch implementations
    /// easily.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface iCacheStuff<T> where T : employee
    {
        string CacheName { get; }
        void AddItem(T newItem);
        T FindItem(Guid id);
        string GetName(Guid id);
    }
}
