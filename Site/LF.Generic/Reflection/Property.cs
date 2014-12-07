using System;
using System.Linq;
using System.Linq.Expressions;

namespace LF.Generics.Reflection
{
    ///<summary>
    /// Helper of PropertyInfo
    ///</summary>
    public static class Property
    {
        /////<summary>
        ///// Give a name of a property, to use lambda expression, not strings
        /////</summary>
        //public static String Name<TOrigin>(Expression<Func<TOrigin>> property)
        //{
        //    return name(property.Body);
        //}

        ///<summary>
        /// Give a name of a property, to use lambda expression, not strings
        ///</summary>
        public static String GetFullPropertyName<TOrigin, TProperty>(this TOrigin model, Expression<Func<TOrigin, TProperty>> property)
        {
            var expression = property.Body.ToString().Split(new[] { '.' }, 2);

            return expression.LastOrDefault();
        }

        ///<summary>
        /// Give a name of a property, to use lambda expression, not strings
        ///</summary>
        public static String GetName<TOrigin, TProperty>(this Expression<Func<TOrigin, TProperty>> property)
        {
            return name(property.Body);
        }

        private static String name(Expression property)
        {
            var expression = property.ToString().Split('.');

            return expression.LastOrDefault();
        }

        public static Type ReferenceType<TObject, TProperty>(this Expression<Func<TObject, TProperty>> property)
        {
            return ((MemberExpression)property.Body).Expression.Type;
        }


    }
}
