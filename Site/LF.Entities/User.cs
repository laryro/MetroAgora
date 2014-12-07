using System;
using System.Collections.Generic;
using LF.Entities.Base;
using LF.Entities.Enums;

namespace LF.Entities
{
    public class User : IEntity
    {

        public User()
        {
            init();
        }

        private void init()
        {
        }

        public virtual Int32 ID { get; set; }

        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual IList<Login> LoginList { get; set; }

        public virtual UserStatus Status { get; set; }
        public virtual Guid? PasswordRecover { get; set; }

        public virtual UserRole Role { get; set; }



        public override string ToString()
        {
            return String.Format("{0} ({1})", Username, Role);
        }
    }
}
