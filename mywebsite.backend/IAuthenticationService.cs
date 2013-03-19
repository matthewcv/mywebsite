using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.AspNet;

namespace mywebsite.backend
{
    public interface IAuthenticationService
    {
        IList<IAuthenticationClient> OAuthClients { get; }

        IAuthenticationClient GetClient(string providerName);

        OpenAuthSecurityManager GetSecurityManager(string providerName);

        LoginResponse Login(AuthenticationResult authResult);

        OAuthIdentity FindOAuthIdentity(string provider, string providerUserId);
    }
}
