using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LF.MVC.Helpers.Views
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString ResourceLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
        {
            var resourceValue = ResourceHelper.GetValue(property);

            return helper.LabelFor(property, resourceValue);
        }

        public static MvcHtmlString ResourceLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property, object htmlAttributes)
        {
            var resourceValue = ResourceHelper.GetValue(property);

            return helper.LabelFor(property, resourceValue, htmlAttributes);
        }

        public static MvcHtmlString ResourceLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property, IDictionary<string, object> htmlAttributes)
        {
            var resourceValue = ResourceHelper.GetValue(property);

            return helper.LabelFor(property, resourceValue, htmlAttributes);
        }



    }
}