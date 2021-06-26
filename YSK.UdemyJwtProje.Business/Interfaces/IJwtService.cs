using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.Business.Interfaces
{
    public interface IJwtService
    {
        string GenereateJwt(AppUser appUser, List<AppRole> roles);
    }
}
