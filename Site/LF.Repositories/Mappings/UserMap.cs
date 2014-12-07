using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using LF.Entities;

namespace LF.DBManager.Mappings
{
    public class UserMap : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.Map(m => m.PasswordRecover).Nullable();
        }
    }
}
