using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    class ClassificationMap : ClassMap<Classification>
    {
        public ClassificationMap()
        {
            Table("Classification");
            Id(x => x.Id);
            Map(x => x.Name);
        }
    
    }
}
