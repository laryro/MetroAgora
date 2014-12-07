using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using LF.Entities.Base;
using LF.Generics.Reflection;

namespace LF.MVC.Helpers.Extensions
{
    public class SelectListExtension
    {
        ///<summary>
        /// Create a SelectList from List of objects
        ///</summary>
        ///<param name="list">The list that will fill the SelectList</param>
        public static SelectList CreateSelect<T>(IEnumerable<T> list)
            where T : IListableEntity
        {
            return new SelectList(list, "ID", "NAME");
        }

        ///<summary>
        /// Create a SelectList from List of objects
        ///</summary>
        ///<param name="list">The list that will fill the SelectList</param>
        ///<param name="value">The property the will fill the values of the options</param>
        ///<param name="text">The property the will fill the text that appears in options</param>
        public static SelectList CreateSelect<TOrigin, TValue, TText>(IList<TOrigin> list, Expression<Func<TOrigin, TValue>> value, Expression<Func<TOrigin, TText>> text)
        {
            var propValueName = value.GetName();
            var propTextName = text.GetName();

            return new SelectList(list, propValueName, propTextName);
        }



        ///<summary>
        /// Create a SelectList from a Enum.
        /// Can't use the number value, MVC don't recognize to assign selected.
        ///</summary>
        public static SelectList CreateSelect<TEnum>()
        {
            var selectList = createSelectFromEnumValues<TEnum>();

            return new SelectList(selectList, "Value", "Text", 0);
        }

        private static IEnumerable<SelectListItem> createSelectFromEnumValues<TEnum>()
        {
            var values = Enum.GetValues(typeof (TEnum)).Cast<Enum>();

            return createSelectFromEnumValues(values);
        }

        ///<summary>
        /// Create a SelectList from a Enum values.
        /// Can't use the number value, MVC don't recognize to assign selected.
        ///</summary>
        public static SelectList CreateSelect(IEnumerable<Enum> values)
        {
            var selectList = createSelectFromEnumValues(values);

            return new SelectList(selectList, "Value", "Text", 0);
        }

        private static IEnumerable<SelectListItem> createSelectFromEnumValues(IEnumerable<Enum> values)
        {
            return values.Select(
                    t =>
                    new SelectListItem
                    {
                        Value = t.ToString(),
                        Text = t.GetName(),
                    }
                );
        }



    }
}