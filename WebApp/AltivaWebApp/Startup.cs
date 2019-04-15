using AltivaWebApp.App_Start;﻿
using AltivaWebApp.Context;
using AltivaWebApp.Filter;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO; // for using Directory

namespace AltivaWebApp
{
    public class Startup
    {

            public IConfiguration Configuration { get; set; }
         public static IHostingEnvironment entorno { get; set; }
        public Startup(IHostingEnvironment env)
            {
            entorno = env;
                     var builder = new ConfigurationBuilder()
                        .SetBasePath(entorno.ContentRootPath)
                        .AddJsonFile("appsettings.json");
                        Configuration = builder.Build();
            }  
          

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            DependencyInjectionConfig.AddScope(services);

            //se agrega el context con un string base en appsettings

            StringFactory.SetStringEmpresas(Configuration.GetConnectionString("EmpresasString"));

            services.AddDbContext<EmpresasContext>(options =>
               options.UseSqlServer(StringFactory.StringEmpresas));

            StringFactory.SetStringGE(Configuration.GetConnectionString("GrupoEmpresarialString") );

            services.AddDbContext<GrupoEmpresarialContext>(options =>
                    options.UseSqlServer(StringFactory.StringGE));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Cuenta/Login/";
                        options.AccessDeniedPath = "/Cuenta/Login/";

                    });

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
           

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(360);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            var supportedCultures = new[] { "es-CR", "en-US" };
            var localizationOptions = new RequestLocalizationOptions();
            localizationOptions.AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures)
                .SetDefaultCulture(supportedCultures[0])
                .RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider() { Options = localizationOptions });
            services.AddSingleton(localizationOptions);
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");

            services.AddMvc(mvcOptions =>
            {
                mvcOptions.Filters.Add(typeof(CultureRedirectFilter));
                mvcOptions.Filters.Add(new MiddlewareFilterAttribute(typeof(LocalizationPipeline)));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RequestLocalizationOptions options)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseSession();


            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=home}/{action=index}");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{culture:regex(^[a-z]{{2}}(\\-[A-Z]{{2}})?$)}/{controller=home}/{action=index}"
                    );
                routes.MapRoute(
                    name: "defaultWithoutLanguage",
                    template: "{controller=home}/{action=index}"
                    );
            });

        }
    }
}
