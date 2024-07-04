using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagement.EF;

namespace EventManagement.Auth
{
    public class User : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)httpContext.Session["user"];
            if (user != null && user.UserType.Equals("User"))
            {
                return true;
            }
            return false;
        }
    }
}