using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern
{
    public class Ticket : EntityBase
    {
        public Guid Id { get; set; }
        public Decimal total { get; set; }

    }
}
