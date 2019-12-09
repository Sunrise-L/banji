using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using banjiguanli.Models;
using banjiguanli.Models.ValidatableObjects;

namespace banjiguanli.Filters
{
    public class RequireAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var user = filterContext.HttpContext.Session["user"]?.ToString();
                if (!string.IsNullOrWhiteSpace(user))
                {
                    return;
                }

                var cookie = filterContext.HttpContext.Request.Cookies?["user"];
                if (!string.IsNullOrEmpty(cookie?.Value))
                {
                    throw new UnauthorizedException();
                }

                var content = cookie?.Value.DecryptQueryString();
                ClassEntities db = new ClassEntities();
                if (!db.Users.Any(u => u.Account == content))
                {
                    throw new UnauthorizedException();
                }
            }
        }
    }
}