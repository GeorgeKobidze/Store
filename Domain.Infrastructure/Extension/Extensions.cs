using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Extension
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings());
        }

        public static string PassswordHasher(string Password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: Password,
               salt: Encoding.Unicode.GetBytes(Password),
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 10000,
               numBytesRequested: 256 / 8
               ));
        }
    }
}
