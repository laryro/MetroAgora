using System;
using System.Collections.Generic;
using LF.Entities.Base;
using LF.Entities.Enums;

namespace LF.Entities
{
    public class Line : IEntity
    {

        public Line()
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
