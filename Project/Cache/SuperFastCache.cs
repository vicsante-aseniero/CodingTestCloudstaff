using System;

namespace Diana.Code.Challenge
{
    /// <question>
    /// Implement this class as required.
    /// </question>
    public class SuperFastCache<T> : iCacheStuff<T> where T : employee
    {
        public string CacheName => "Super Fast Cache x1000 faster!\r\n\r\nTODO: Please Implement this class and make it super fast.\r\n";

        public SuperFastCache()
        {
        }

        public void AddItem(T newItem)
        {
            throw new NotImplementedException("Please implement the AddItem method.");
        }

        public string GetName(Guid id)
        {
            throw new NotImplementedException("Please implement the GetName method.");
        }

        T FindItem(Guid id)
        {
            throw new NotImplementedException("Please implement the FindItem method.");
        }
    }
}
