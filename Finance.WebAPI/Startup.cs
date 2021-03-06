using Docker.DotNet.Models;
using Finance.Data.Models;
using Finance.WebAPI.App_Start;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Reso.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Finance.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddCors(options =>
            //{

            //    options.AddPolicy(MyAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder
            //        .WithOrigins(GetDomain())
            //        .AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //    });
            //});
            services.AddRazorPages();
            //services.JsonFormatConfig();
            services.ConfigureSwagger();
            services.AddDbContext<financeFPTContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("FinanceFPTDatabase"))
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.ConfigMemoryCacheAndRedisCache(Configuration["Redis"]);
            services.AddHttpClient();
            services.ConfigureAutoMapper();
            services.ConfigureDI();
            services.ConfigureServiceWorkers();
            services.ConfigDataProtection();
            //using var json = Assembly.GetExecutingAssembly()
            //    .GetManifestResourceStream("VuonDau.WebApi.Firebase.firebase_config.json");
            //var something = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //FirebaseApp.Create(new AppOptions
            //{
            //    Credential = GoogleCredential.FromStream(json)
            //});
            //services.AddRouting();
            //AuthConfig.ConfigAuthentication(services, Configuration);
        }
        private string[] GetDomain()
        {
            var domains = Configuration.GetSection("Domain").Get<Dictionary<string, string>>()
            .SelectMany(s => s.Value.Split(",")).ToArray();
            return domains;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finance.WebApi v1"));
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            #region Multi lang
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.Use((context, next) =>
            {
                var userLangs = context.Request.Headers["accept-language"].ToString();
                var lang = userLangs.Split(',').FirstOrDefault();
                if (string.IsNullOrEmpty(lang))
                {
                    lang = "vi";
                }
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                context.Items["SelectedLng"] = lang;
                context.Items["ClientCulture"] = Thread.CurrentThread.CurrentUICulture.Name;
                return next();
            });
            #endregion
            app.ConfigMigration<financeFPTContext>();
            app.ConfigureErrorHandler(env);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ConfigureSwagger(provider);
        }
    }
}
