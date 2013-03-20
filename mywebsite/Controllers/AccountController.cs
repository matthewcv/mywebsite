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
        private class SessionKeys
        {
            public const string CreateProfile = "CreateProfile";
        }
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
            if (Request.IsAuthenticated)
            {
                return View("Login");
            }
            return new OAuthRequestActionResult(_authService.GetSecurityManager(provider), Url.Action("RequestAuthCallback"));
        }
        [AllowAnonymous]
        public ActionResult RequestAuthCallback()
        {
            if (Request.IsAuthenticated)
            {
                return View("Login");
            }

            string providerName = OpenAuthSecurityManager.GetProviderName(HttpContext);
            OpenAuthSecurityManager m = _authService.GetSecurityManager(providerName);
            AuthenticationResult verifyAuthentication = m.VerifyAuthentication(Url.Action("RequestAuthCallback"));

            if (verifyAuthentication.IsSuccessful)
            {
                LoginResponse loginResponse = _authService.Login(verifyAuthentication);
                if (loginResponse.NewProfileCreated)
                {
                    Session[SessionKeys.CreateProfile] = true;
                    return RedirectToAction("Edit");
                }
            }


            return RedirectToAction("Login");
        }

        public ActionResult Edit()
        {
            
            if (Session[SessionKeys.CreateProfile] != null)
            {
                ViewBag.CreateProfile = true;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {


            return View();
        }


        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
