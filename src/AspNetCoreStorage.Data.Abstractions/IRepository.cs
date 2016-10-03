﻿// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace AspNetCoreStorage.Data.Abstractions
{
  public interface IRepository
  {
    void SetStorageContext(IStorageContext storageContext);
  }
}