using System;
using System.Collections.Generic;
using System.Text;
using YSK.UdemyJwtProje.Business.Interfaces;
using YSK.UdemyJwtProje.DataAccess.Interfaces;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.Business.Concrete
{
    public class AppUserRoleManager:GenericManager<AppUserRole>,IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal):base(genericDal)
        {

        }
    }
}
