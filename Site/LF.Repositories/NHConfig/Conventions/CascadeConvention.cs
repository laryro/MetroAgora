using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace LF.DBManager.NHConfig.Conventions
{
    internal class CascadeConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Cascade.None();
        }
    }
}
