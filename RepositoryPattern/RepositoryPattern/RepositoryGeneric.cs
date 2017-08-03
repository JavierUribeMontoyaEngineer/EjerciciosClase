using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern
{
    public class RepositoryGeneric<T> where T:EntityBase
    {
        public virtual void Add(T entity)
        {
            entity.id = EntityBase.CreateIdentifier();
        }

    }
}
