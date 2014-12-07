using System;
using System.Web;
using LF.Authentication;
using LF.Entities.Enums;
using LF.Generics.Reflection;
using LF.MVC.Helpers.Extensions;
using LF.MVC.Helpers.Models;
using LF.Services;
using UrlHelper = System.Web.Mvc.UrlHelper;

namespace LF.MVC.Models
{
    public class BaseModel
    {
        public AllServices Access
        {
            get { return AllServices.Access; }
        }

        public Current Current
        {
            get { return Access.Current; }
        }

        public Boolean IsAuthorized(UserRole role)
        {
            return Current.IsAuthorized(role);
        }

        public Boolean IsAuthenticated
        {
            get { return Current.IsAuthenticated; }
        }




        protected Int32 ID
        {
            get
            {
                var routeId = RouteInfo.Current.RouteData.Values["id"].ToString();

                return String.IsNullOrEmpty(routeId)
                    ? 0
                    : Int32.Parse(routeId);
            }
        }

        public static UrlHelper Url
        {
            get { return new UrlHelper(HttpContext.Current.Request.RequestContext);}
        }


    }
}