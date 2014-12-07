using System;
using LF.Entities.Base;

namespace LF.Entities
{
    public class Occurrence : IEntity
    {
        public virtual Int32 ID { get; set; }

        public virtual String Description { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual Station Station { get; set; }

    }
}