using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mywebsite.backend;

namespace mywebsite.Infrastructure
{
    public class ProfileFilterAttribute:ActionFilterAttribute
    {
        private readonly IAuthenticationService _authService;

        public ProfileFilterAttribute(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CurrentProfile = _authService.CurrentProfile;
        }
    }
}