using System;
using FluentNHibernate.Mapping;

namespace LF.DBManager.NHConfig.Helpers
{
    internal static class PropertyPartExtension
    {
        public static PropertyPart ReallyBigString(this PropertyPart propertyPart)
        {
            return propertyPart
                .CustomType("StringClob")
                .CustomSqlType("varchar(max)")
                .Length(Int32.MaxValue);
        }
    }
}