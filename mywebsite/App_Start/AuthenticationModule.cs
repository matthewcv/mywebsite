﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using FluentValidation;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Raven.Client;
using mywebsite.Infrastructure;
using mywebsite.backend;

namespace mywebsite.App_Start
{
    public class AuthenticationModule:NinjectModule
    {
        public override void Load()
        {
            //Bind<IOpenAuthDataProvider>().To<OAuthDataProvider>().InRequestScope();
            Bind<IAuthenticationService, IOpenAuthDataProvider>().ToMethod(CreateAuthContext).InRequestScope();
            this.BindFilter<ProfileFilterAttribute>(FilterScope.First,0);
        }

        private AuthenticationService CreateAuthContext(IContext arg)
        {
            return new AuthenticationService(arg.Kernel.Get<HttpContextBase>(),arg.Kernel.Get<IDocumentSession>())
                .AddClient(new GoogleOpenIdClient());

        }
    }
}