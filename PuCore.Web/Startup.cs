using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PuCore.EntityFramework.EntityFramework;
using Microsoft.EntityFrameworkCore;
using PuCore.Utility.config;
using PuCore.Application.UserApp;
using PuCore.Domain.IRepositories;
using PuCore.EntityFramework.Repositories;
using System.Reflection;
using PuCore.Domain;

namespace PuCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //数据库连接
            services.AddDbContext<PuCoreDbContext>(options => options.UseMySql(AppConfig.MySqlConnection));

            //依赖注入
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();


            services.AddMvc();
        }

   
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
            SeedData.Initialize();
        }
    }
}
