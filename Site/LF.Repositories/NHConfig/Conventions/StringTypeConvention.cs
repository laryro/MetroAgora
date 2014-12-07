using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace LF.DBManager.NHConfig.Conventions
{
    public class StringTypeConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type.GetUnderlyingSystemType() == typeof(String))
                instance.CustomType("AnsiString");
        }
    }
}
