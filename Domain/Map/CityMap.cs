using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    class CityMap : ClassMap<City> 
    {
        public CityMap()
        {
            Table("City");
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.Region, "RegionId");
        }
    }

}
