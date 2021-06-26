using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.UdemyJwtProje.Entities.Interfaces;

namespace YSKProje.UdemyJwtProje.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto:IDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
