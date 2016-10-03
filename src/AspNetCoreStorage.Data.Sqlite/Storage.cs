// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using AspNetCoreStorage.Data.Abstractions;

namespace AspNetCoreStorage.Data.Sqlite
{
  public class Storage : IStorage
  {
    public StorageContext StorageContext { get; private set; }

    public Storage()
    {
      this.StorageContext = new StorageContext("Data Source=..\\..\\..\\db.sqlite");
    }

    public T GetRepository<T>() where T : IRepository
    {
      foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
      {
        if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
        {
          T repository = (T)Activator.CreateInstance(type);

          repository.SetStorageContext(this.StorageContext);
          return repository;
        }
      }

      return default(T);
    }

    public void Save()
    {
      this.StorageContext.SaveChanges();
    }
  }
}