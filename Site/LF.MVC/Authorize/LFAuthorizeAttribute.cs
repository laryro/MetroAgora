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
                && current.User.Status != UserStatus.FirstAccess
                && (Role == 0 || current.IsAuthorized(Role));
        }

        private Current current
        {
            get { return AllServices.Access.Current; }
        }

        private Boolean needChangePassword
        {
            get
            {
                return current.IsAuthenticated
                    && current.User.Status == UserStatus.FirstAccess;
            }
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
                filterContext.Result = needChangePassword 
                    ? new RedirectResult(url.Action("ChangePassword", "Users")) 
                    : new RedirectResult(url.Action("Index", "Home"));
            }
            else
            {
                filterContext.Result = new RedirectResult(url.Action("Login", "Users"));
            }
        }

        private static UrlHelper url
        {
            get { return new UrlHelper(HttpContext.Current.Request.RequestContext); }
        }


    }

}