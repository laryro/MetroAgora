using System;
using System.Web;
using System.Web.Mvc;
using LF.Authentication;
using LF.Entities.Enums;
using LF.Services;

namespace LF.MVC.Authorize
{
    public class LFAuthorizeAttribute : AuthorizeAttribute
    {
        public enum Caller
        {
            Normal,
            Ajax,
        }

        public Caller Call;
        public UserRole Role;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return current.IsAuthenticated
                && (Role == 0 || current.IsAuthorized(Role));
        }

        private Current current
        {
            get { return AllServices.Access.Current; }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (Call == Caller.Ajax)
            {
                filterContext.Result = new ContentResult { Content = "-" };
                return;
            }

            if (current.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(url.Action("Index", "Home"));
            }
            else
            {
                var cameFrom = HttpContext.Current.Request.Url.PathAndQuery;
                filterContext.Result = new RedirectResult(url.Action("Login", "Users", new { backTo = cameFrom }));
            }
        }

        private static UrlHelper url
        {
            get { return new UrlHelper(HttpContext.Current.Request.RequestContext); }
        }


    }

}