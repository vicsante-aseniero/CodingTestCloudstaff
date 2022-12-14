using System;
using System.Collections.Generic;
using System.Linq;

namespace Diana.Code.Challenge
{
 /// <question>
 /// Implement this class as required.
 /// </question>
 public sealed class SuperFastCache<T> : iCacheStuff<T> where T : employee
 {
  private static readonly SuperFastCache<T> instance = new SuperFastCache<T>(); // Non-lazy or Eager loading Singleton Design Pattern
  internal static Dictionary<Guid, T> Items { get; private set; } = new Dictionary<Guid, T>();
  public string CacheName => "Super Fast Cache x1000 faster!\r\n\r\nTODO: Please Implement this class and make it super fast.\r\n";

  private SuperFastCache()
  {
  }

  public static SuperFastCache<T> GetInstance
  {
   get
   {
    return instance;
   }
  }

  public void AddItem(T newItem)
  {
   //throw new NotImplementedException("Please implement the AddItem method.");
   Items.Add(newItem.Id, newItem);
  }

  public string GetName(Guid id)
  {
   //throw new NotImplementedException("Please implement the GetName method.");
   return FindItem(id)?.name;
  }

  public T FindItem(Guid id)
  {
   //throw new NotImplementedException("Please implement the FindItem method.");
   return Items[id];
  }
 }
}
