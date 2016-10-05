// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AspNetCoreStorage.Data.Abstractions;
using AspNetCoreStorage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStorage.Data.Sqlite
{
  public class ItemRepository : IItemRepository
  {
    private StorageContext storageContext;
    private DbSet<Item> dbSet;

    public void SetStorageContext(IStorageContext storageContext)
    {
      this.storageContext = storageContext as StorageContext;
      this.dbSet = this.storageContext.Set<Item>();
    }

    public IEnumerable<Item> All()
    {
      return this.dbSet.OrderBy(i => i.Name);
    }
  }
}