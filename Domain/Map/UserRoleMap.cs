using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("UserRole");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.IsAdmin);
        }

    }
}
