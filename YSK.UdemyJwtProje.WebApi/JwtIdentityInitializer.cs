using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSK.UdemyJwtProje.Business.Interfaces;
using YSK.UdemyJwtProje.Business.StringInfos;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            //ilgili rol var mı?
            var AdminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (AdminRole == null)
            {
                appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var MemberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (MemberRole == null)
            {
                appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }
            var adminUser = await appUserService.FindByUserName("Deniz");
            if(adminUser ==null)
            {
                await appUserService.Add(new AppUser
                {
                    FullName = "Deniz Uzundag",
                    UserName = "Deniz",
                    Password="1"

                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("Deniz");

               await  appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });

            }
            
        }


    }
}
