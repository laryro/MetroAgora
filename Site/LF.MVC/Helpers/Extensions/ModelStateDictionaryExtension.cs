using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc;
using LF.Generics.Reflection;

namespace LF.MVC.Helpers.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static void SetValue<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> property, object value)
        {
            var key = property.GetName();
            var newValue = new ValueProviderResult(value, "", CultureInfo.CurrentCulture);

            modelState.SetModelValue(key, newValue);
        }

    }
}