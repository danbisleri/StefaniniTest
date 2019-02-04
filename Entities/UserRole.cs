using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserRole : Entity
    {
        public virtual string Name { get; set; }
        public virtual bool IsAdmin { get; set; }
    }
}
