using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07_Step1_DomainEvent.Management
{
    public class HeadOfficeMap : ClassMap<HeadOffice>
    {
        public HeadOfficeMap()
        {
            Id(x => x.Id);

            Map(x => x.Balance);

            Component(x => x.Cash, y =>
            {
                y.Map(x => x.OneCentCount);
                y.Map(x => x.TenCentCount);
                y.Map(x => x.QuarterCount);
                y.Map(x => x.OneDollarCount);
                y.Map(x => x.FiveDollarCount);
                y.Map(x => x.TwentyDollarCount);
            });
        }
    }
}
