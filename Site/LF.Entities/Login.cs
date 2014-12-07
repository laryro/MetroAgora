using System;
using LF.Entities.Base;

namespace LF.Entities
{
    public class Login : IEntity
    {
        public virtual Int32 ID { get; set; }

        public virtual String Ticket { get; set; }

        public virtual User User { get; set; }
    }
}