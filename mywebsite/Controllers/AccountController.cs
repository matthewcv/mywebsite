using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using DotNetOpenAuth.OpenId.RelyingParty;
using Raven.Client;
using mywebsite.App_Start;
using mywebsite.Infrastructure;
using mywebsite.backend;

namespace mywebsite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
            
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View(_authService.OAuthClients);
        }

        [AllowAnonymous]
        public ActionResult RequestAuth(string provider)
        {

            return new OAuthRequestActionResult(_authService.GetSecurityManager(provider),Url.Action("RequestAuthCallback"));
        }
        [AllowAnonymous]
        public ActionResult RequestAuthCallback()
        {
            string providerName = OpenAuthSecurityManager.GetProviderName(HttpContext);
            OpenAuthSecurityManager m = _authService.GetSecurityManager(providerName);
            AuthenticationResult verifyAuthentication = m.VerifyAuthentication(Url.Action("RequestAuthCallback"));

            
            
            return null;
        }


        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            return RedirectToAction("Index", "Home");
        }
    }
}
