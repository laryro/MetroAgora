using System;
using System.Linq.Expressions;
using LF.Generics.Reflection;

namespace LF.DBManager
{
    public class SearchItem<T>
    {
        public SearchItem(Expression<Func<T, object>> property, String term)
        {
            Property = property;
            Term = term;
        }

        public Expression<Func<T, object>> Property { get; private set; }
        public String Term { get; private set; }

        public Type ParentType()
        {
            return Property.ReferenceType();
        }


    }


}