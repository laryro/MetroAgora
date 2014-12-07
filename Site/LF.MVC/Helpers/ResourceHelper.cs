using System;
using System.Linq.Expressions;
using Resources;
using LF.Generics.Reflection;
using LF.MVC.Helpers.Models;

namespace LF.MVC.Helpers
{
    public class ResourceHelper
    {
        public static String GetValue<TModel, TProperty>(Expression<Func<TModel, TProperty>> property)
        {
            var propertyName = property.GetName();

            return GetValue(propertyName);
        }

        public static String GetValue(String propertyName)
        {
            var routeInfo = RouteInfo.Current.RouteData.Values;
            var controller = routeInfo["controller"];
            var action = routeInfo["action"];

            var resourceKey = controller + "_" + action + "_" + propertyName;
            var resourceValue = DisplayNames.ResourceManager.GetString(resourceKey);

            if (String.IsNullOrEmpty(resourceValue))
            {
                resourceKey = controller + "_" + propertyName;
                resourceValue = DisplayNames.ResourceManager.GetString(resourceKey);
            }

            if (String.IsNullOrEmpty(resourceValue))
            {
                resourceKey = propertyName;
                resourceValue = DisplayNames.ResourceManager.GetString(resourceKey);
            }

            return resourceValue;
        }


    }
}