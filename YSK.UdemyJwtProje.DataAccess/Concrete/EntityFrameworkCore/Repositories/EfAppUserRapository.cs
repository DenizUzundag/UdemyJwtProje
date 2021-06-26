using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSK.UdemyJwtProje.DataAccess.Concrete.EntityFrameworkCore.Context;
using YSK.UdemyJwtProje.DataAccess.Interfaces;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRapository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            using var context = new UdemyJwtContext();
            return await context.AppUsers.Join(context.AppUserRoles, u => u.Id, ur =>
            ur.AppUserId, (user, userRole) =>new
            {
                user = user,
                userRole = userRole



            }).Join(context.AppRoles, two => two.userRole.AppRoleId, r => r.Id, (twoTable, role) => new
            {
                user = twoTable.user,
                userRole = twoTable.userRole,
                role = role
            }).Where(I => I.user.UserName == userName).Select(I => new AppRole
            {

                Id = I.role.Id,
                Name = I.role.Name
            }).ToListAsync();
        }
    }
}
