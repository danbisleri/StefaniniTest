using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceRegion : Service<City>
    {
        public virtual IEnumerable<Region> GetRegions(string cityId)
        {
            IEnumerable<Region> regions;
            if (string.IsNullOrEmpty(cityId))
                regions = _session.Query<Region>();  
            else
                regions = _session.Query<City>().Where(c => cityId == c.Id.ToString()).Select(r => r.Region).ToList();

            return regions;
        }
    }
}
