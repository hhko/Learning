using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05_Step1_Repo
{
    public class SlotMap : ClassMap<Slot>
    {
        public SlotMap()
        {
            Id(x => x.Id);
            Map(x => x.Position);

            // Value Object
            Component(x => x.SnackPile, y =>
            {
                y.Map(x => x.Quantity);
                y.Map(x => x.Price);

                //
                // 다른 영역의 AggregateRoot는 함께 읽어 들이지 않는다.
                //
                y.References(x => x.Snack).Not.LazyLoad();
            });

            // AggregateRoot(Entity)
            References(x => x.SnackMachine);
        }
    }
}
