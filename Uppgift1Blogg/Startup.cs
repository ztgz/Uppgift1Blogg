﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uppgift1Blogg.Models;

namespace Uppgift1Blogg
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Connectionsträngen bör egentligen ligga I en config fil men vi tittar mer
            //på det senare
            var conn = @"Server=localhost;Database=Blogg;Trusted_Connection=True; ConnectRetryCount=0";

            services.AddDbContext<BloggContext>(options => options.UseSqlServer(conn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
                {
                    routes.MapRoute( name: "default",
                        template: "{controller=Blog}/{action=Index}/{id?}"
                        );
                }
            );
        }
    }
}
