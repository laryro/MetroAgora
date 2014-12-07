using System;
using LF.Entities.Base;

namespace LF.Entities
{
    public class Category : IEntity
    {
        public Category()
        {
            init();
        }

        private void init()
        {
        }

        public virtual Int32 ID { get; set; }

        public virtual String Name { get; set; }
    }
}