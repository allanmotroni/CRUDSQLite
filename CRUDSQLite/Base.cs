using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSQLite
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        protected Base()
        {
            Id = Guid.NewGuid();
        }
    }
}
