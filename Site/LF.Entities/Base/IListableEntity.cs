using System;

namespace LF.Entities.Base
{
    public interface IListableEntity : IEntity
    {
        String Name { get; set; }
    }
}
