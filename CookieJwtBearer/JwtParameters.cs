using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CookieJwtBearer
{
    public static class JwtParameters
    {
        static JwtParameters()
        {
            using (var algorithm = Aes.Create())
            {
                SigningKey = algorithm.Key;
            }
        }

        public static byte[] SigningKey { get; private set; }

        public static string Issuer => "contoso.com";

        public static string Audience => "localhost";

        public static TimeSpan ValidFor => new TimeSpan(0, 5, 0);
    }
}
