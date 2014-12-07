using System;
using LF.Entities.Base;

namespace LF.Entities
{
    public class Station : IEntity
    {
        public Station()
        {
            init();
        }

        private void init()
        {
        }

        public virtual Int32 ID { get; set; }

        public virtual String Name { get; set; }

        public virtual Line Line { get; set; }
    }
}