using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace GET.Spooler.Base
{
    public abstract class JwtProvider
    {
        private static string jwtToken;
        protected abstract int ExpiryInMins { get; }
        protected abstract bool UseUTC { get; }
        protected abstract Task<string> RenewJwt();


        public async Task<string> RefreshJwt()
        {
            if (jwtToken == null || IsExpiredToken())
            {
                jwtToken = await RenewJwt();
            }
            return jwtToken;
        }

        private bool IsExpiredToken()
        {
            var jwthandler = new JwtSecurityTokenHandler();
            var jwttoken = jwthandler.ReadToken(jwtToken);
            var expDate = jwttoken.ValidTo;
            return expDate < (UseUTC ? DateTime.UtcNow : DateTime.Now).AddMinutes(ExpiryInMins);
        }
    }
}