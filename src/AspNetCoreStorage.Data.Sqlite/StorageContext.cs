// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreStorage.Data.Abstractions;
using AspNetCoreStorage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStorage.Data.Sqlite
{
  public class StorageContext : DbContext, IStorageContext
  {
    private string connectionString;

    public StorageContext(string connectionString)
    {
      this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlite(this.connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Item>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id);
          etb.ForSqliteToTable("Items");
        }
      );
    }
  }
}