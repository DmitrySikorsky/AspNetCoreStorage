// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AspNetCoreStorage.Data.Abstractions;
using AspNetCoreStorage.Data.Models;

namespace AspNetCoreStorage.Data.Mock
{
  public class ItemRepository : IItemRepository
  {
    public readonly IList<Item> items;

    public ItemRepository()
    {
      this.items = new List<Item>();
      this.items.Add(new Item() { Id = 1, Name = "Mock item 1" });
      this.items.Add(new Item() { Id = 2, Name = "Mock item 2" });
      this.items.Add(new Item() { Id = 3, Name = "Mock item 3" });
    }

    public void SetStorageContext(IStorageContext storageContext)
    {
      // Do nothing
    }

    public IEnumerable<Item> All()
    {
      return this.items.OrderBy(i => i.Name);
    }
  }
}