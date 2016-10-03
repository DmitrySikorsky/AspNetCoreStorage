// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreStorage.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreStorage.Controllers
{
  public class HomeController : Controller
  {
    private IStorage storage;

    public HomeController(IStorage storage)
    {
      this.storage = storage;
    }

    public ActionResult Index()
    {
      return this.View(this.storage.GetRepository<IItemRepository>().All());
    }
  }
}