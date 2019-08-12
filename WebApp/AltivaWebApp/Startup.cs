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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using AltivaWebApp.Helpers;
using Microsoft.Extensions.FileProviders;
using System.IO;

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
            services.AddDbContext<BaseConta>();
            services.AddDbContext<EmpresasContext>();
            services.AddDbContext<GrupoEmpresarialContext>();
         


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

            services.AddHttpContextAccessor();
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

            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseFastReport();



            AltivaWebApp.Helpers.StringProvider.Configure(app.ApplicationServices
                      .GetRequiredService<IHttpContextAccessor>());
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

    public class MsSqlDataConnection : FastReport.Data.DataConnectionBase
    {
        public override string QuoteIdentifier(string value, System.Data.Common.DbConnection connection)
        {
            return "\"" + value + "\"";
        }

        public override System.Type GetConnectionType()
        {
            return typeof(System.Data.SqlClient.SqlConnection);
        }

        public override System.Type GetParameterType()
        {
            return typeof(System.Data.SqlDbType);
        }

        public override System.Data.Common.DbDataAdapter GetAdapter(string selectCommand, System.Data.Common.DbConnection connection, FastReport.Data.CommandParameterCollection parameters)
        {
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(selectCommand, connection as System.Data.SqlClient.SqlConnection);
            foreach (FastReport.Data.CommandParameter p in parameters)
            {
                System.Data.SqlClient.SqlParameter parameter = adapter.SelectCommand.Parameters.Add(p.Name, (System.Data.SqlDbType)p.DataType, p.Size);
                parameter.Value = p.Value;
            }
            return adapter;
        }
    }
}
