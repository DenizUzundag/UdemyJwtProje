using System;
using System.Collections.Generic;
using System.Text;
using YSK.UdemyJwtProje.DataAccess.Interfaces;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository:EfGenericRepository<AppUserRole>,IAppUserRoleDal
    {
    }
}
