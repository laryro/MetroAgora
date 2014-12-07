using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Conventions;
using LF.DBManager.NHConfig.Conventions;
using LF.DBManager.NHConfig.Helpers;

namespace LF.DBManager.NHConfig.UserPassed
{
    /// <summary>
    /// Information to use Automapping of Fluent
    /// </summary>
    /// <typeparam name="TM">Some of the AutoMaps, just for reference</typeparam>
    /// <typeparam name="TE">Some of the Entities, just for reference</typeparam>
    //public class AutoMappingInfo<TM, TE> where TM : IAutoMappingOverride<TE>
    public class AutoMappingInfo<TM, TE> where TM : IAutoMappingOverride<TE>
    {
        /// <summary>
        /// BaseEntities, if it exists, to be ignored on mapping
        /// </summary>
        public Type[] BaseEntities { get; set; }

        /// <summary>
        /// Classes which subclasses use its table
        /// </summary>
        public Type[] SuperEntities { get; set; }

        /// <summary>
        /// Conventions to configure Fluent
        /// </summary>
        public IConvention[] Conventions { get; set; }



        internal AutoPersistenceModel CreateAutoMapping()
        {
            var storeConfiguration = new StoreConfiguration(typeof(TE), SuperEntities);
            var assembly = typeof(TE).Assembly;

            var autoMap = AutoMap
                .Assemblies(storeConfiguration, assembly)
                .UseOverridesFromAssemblyOf<TM>()
                .Conventions.AddFromAssemblyOf<EnumConvention>()
                .Conventions.Add(
                    new NullableConvention.Property(),
                    new NullableConvention.Reference(),
                    new NameConvention.ManyToMany(),
                    new NameConvention.HasMany(),
                    new NameConvention.Reference()
                );

            if (BaseEntities != null)
            {
                foreach (var baseEntity in BaseEntities)
                {
                    autoMap = autoMap.IgnoreBase(baseEntity);
                }
            }

            if (Conventions != null)
                autoMap = autoMap.Conventions.Add(Conventions);

            return autoMap;
        }
    
    }
}
