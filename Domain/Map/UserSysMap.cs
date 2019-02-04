using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    class UserSysMap : ClassMap<UserSys>
    {
        public UserSysMap()
        {
            Table("UserSys");
            Id(x => x.Id);
            Map(x => x.Email);
            Map(x => x.Login);
            Map(x => x.Password);
            References(x => x.UserRole, "UserRoleId");
        }
    }
}
