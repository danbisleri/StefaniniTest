using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.LastPurchase);
            Map(x => x.Phone);

            References(x => x.City, "CityId");
            References(x => x.Classification, "ClassificationId");
            References(x => x.Gender, "GenderId");
            References(x => x.Region, "RegionId");
            References(x => x.UserSys, "UserId");
        }
    }
    
}
