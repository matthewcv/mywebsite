using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using Raven.Client;
using mywebsite.backend;

namespace mywebsite.App_Start
{
    public class AuthenticationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IOpenAuthDataProvider>().To<OAuthDataProvider>().InRequestScope();
            Bind<IAuthenticationService>().ToMethod(CreateAuthContext).InRequestScope();
        }

        private IAuthenticationService CreateAuthContext(IContext arg)
        {
            return new AuthenticationService(arg.Kernel.Get<HttpContextBase>(), arg.Kernel.Get<IOpenAuthDataProvider>(),arg.Kernel.Get<IDocumentSession>())
                .AddClient(new GoogleOpenIdClient());

        }
    }
}