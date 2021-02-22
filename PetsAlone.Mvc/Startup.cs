using Domain;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetsAlone.Mvc.Modules;
using PetsAlone.Mvc.Modules.Common;
using System;

namespace PetsAlone.Mvc
{
    public class Startup
    {

        public Startup(IConfiguration configuration) => this.Configuration = configuration;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // This in-memory implementation is acceptable for now
            //services.AddDbContext<DataContextFake>(opts =>
            //{
            //    static DbConnection CreateInMemoryDatabase()
            //    {
            //        var connection = new SqliteConnection("Filename=PetsAlone.db");
            //        connection.Open();
            //        return connection;
            //    }

            //    opts.UseSqlite(CreateInMemoryDatabase());
            //});

            //????
            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddEntityFrameworkStores<DataContextFake>();
            services
                          .AddFeatureFlags(this.Configuration) // should be the first one.
                          .AddSQLServer(this.Configuration)
                          .AddHealthChecks(this.Configuration)
                          .AddAuthentication(this.Configuration)
                          .AddUseCases()
                          .AddCustomControllers();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Users/Login";
                    options.LogoutPath = "/Users/Logout";
                });
            //services.AddScoped<IPetsService, PetsService> ();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews(); 
            //services.AddTransient(s => s.GetService<HttpContext>()?.User);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable IDE0060 // Remove unused parameter
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pets}/{action=Index}/{id?}");
            });
        }
    }
}