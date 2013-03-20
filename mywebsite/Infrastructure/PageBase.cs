using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mywebsite.backend;

namespace mywebsite.Infrastructure
{

    public abstract class PageBase<T> : System.Web.Mvc.WebViewPage<T>
    {
        public Profile CurrentProfile 
        { 
            get
            {
                return ViewBag.CurrentProfile as Profile;   
            }
        }


    }
}