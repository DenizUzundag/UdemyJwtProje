using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.UdemyJwtProje.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
