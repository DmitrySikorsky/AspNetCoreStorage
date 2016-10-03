// Copyright © 2016 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreStorage.Data.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreStorage
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      // Uncomment to use mock storage
      services.AddScoped(typeof(IStorage), typeof(AspNetCoreStorage.Data.Mock.Storage));
      // Uncomment to use SQLite storage
      //services.AddScoped(typeof(IStorage), typeof(AspNetCoreStorage.Data.Sqlite.Storage));
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
    {
      if (hostingEnvironment.IsDevelopment())
      {
        applicationBuilder.UseDeveloperExceptionPage();
      }

      applicationBuilder.UseMvcWithDefaultRoute();
    }
  }
}