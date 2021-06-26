using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSK.UdemyJwtProje.Business.Containers.MicrosoftIoc;
using YSK.UdemyJwtProje.Business.Interfaces;
using YSK.UdemyJwtProje.Business.StringInfos;
using YSK.UdemyJwtProje.WebApi.CustomFilters;

namespace YSK.UdemyJwtProje.WebApi
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
            services.AddDependencies();
            services.AddScoped(typeof(ValidId<>));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false; //http ile çalýþýyoruz.
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = JwtInfo.Issuer,
                    ValidAudience = JwtInfo.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddControllers().AddFluentValidation();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();
          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAppUserService appUserService, IAppUserRoleService appUserRoleService, 
            IAppRoleService appRoleService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");//Bir hata oluþtuðu zaman bu path'e git
            JwtIdentityInitializer.Seed(appUserService, appUserRoleService, appRoleService).Wait();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();//token için
            app.UseStaticFiles();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
