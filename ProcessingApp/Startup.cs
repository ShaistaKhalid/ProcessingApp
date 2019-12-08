using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessingApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessingApp.Models;

namespace ProcessingApp
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
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = "062bce62-e872-47c4-a42f-7612f21c76c9";
                microsoftOptions.ClientSecret = "VlpOK/uAtOQFIy5si8:Gf:6z2_DPztxu";
            });





            services.AddAuthentication()
     .AddGoogle(options =>
     {
         IConfigurationSection googleAuthNSection =
             Configuration.GetSection("Authentication:Google");

         options.ClientId = "1026638166142-l97l6va48qd1rmhsqdask9ub1ca76p7c.apps.googleusercontent.com";
         options.ClientSecret = "JXUPH-zWmF1mVvEIwg0n9tXS";
     });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*           services.AddMvc().AddRazorPagesOptions(options => {
               options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
           }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            */


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            
            // Crete an Identity based on Application User and Application Role
            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ApplicationDbContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //this is another routing to completely separated page
                routes.MapRoute(
                    name: "customRoute",
                    template: "customRoute/{controller}/{action}/{id?}");

            });

            AddUserData.Initialize(context, userManager, roleManager).Wait();
        }
    }
}
