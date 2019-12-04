using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Repositories;
using Logic;
using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MammalsCore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IGameContext, GameContext>();
            services.AddSingleton<IReviewContext, ReviewContext>();
            services.AddSingleton<IUserContext, UserContext>();
            services.AddSingleton<IAdminContext, AdminContext>();


            services.AddSingleton<IAdminGameRepository, GameRepository>();
            services.AddSingleton<IGameContainerGameRepository, GameRepository>();

            services.AddSingleton<IGameReviewRepository, ReviewRepository>();
            services.AddSingleton<IReviewReviewRepository, ReviewRepository>();
            services.AddSingleton<IUserReviewRepository, ReviewRepository>();

            services.AddSingleton<IUserUserRepository, UserRepository>();
            services.AddSingleton<IUserContainerUserRepository, UserRepository>();

            services.AddSingleton<IAdminLogic, AdminLogic>();
            services.AddSingleton<IGameContainerLogic, GameContainerLogic>();
            services.AddSingleton<IGameLogic, GameLogic>();
            services.AddSingleton<IReviewLogic, ReviewLogic>();
            services.AddSingleton<IUserContainerLogic, UserContainerLogic>();
            services.AddSingleton<IUserLogic, UserLogic>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
