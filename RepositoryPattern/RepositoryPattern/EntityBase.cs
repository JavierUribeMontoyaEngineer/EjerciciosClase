using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern
{
    public abstract class EntityBase
    {
        public Guid id { get; set; }
        public static Guid CreateIdentifier()
        {
            return Guid.NewGuid();
        }
    }
}
