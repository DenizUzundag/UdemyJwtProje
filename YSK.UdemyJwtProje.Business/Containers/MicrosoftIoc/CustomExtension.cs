using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using YSK.UdemyJwtProje.Business.Concrete;
using YSK.UdemyJwtProje.Business.Interfaces;
using YSK.UdemyJwtProje.Business.ValidationRules.FluentValidation;
using YSK.UdemyJwtProje.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSK.UdemyJwtProje.DataAccess.Interfaces;
using YSKProje.UdemyJwtProje.Entities.Dtos.AppUserDtos;
using YSKProje.UdemyJwtProje.Entities.Dtos.ProductDtos;

namespace YSK.UdemyJwtProje.Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public  static void AddDependencies(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped<IProductDal,EfProductRepository>();
            services.AddScoped<IProductService,ProductManager>();

            services.AddScoped<IAppUserDal,EfAppUserRapository>();
            services.AddScoped<IAppUserService,AppUserManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            //her istekte  ayrı bir nesne örneği alıyor 
            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();

            services.AddTransient<IValidator<ProductUpdateDto>,ProductUpdateDtoValidator>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
        }
    }
}
