using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04_Step1_Aggregate
{
    //public class Snack : Entity
    public class Snack : AggregateRoot
    {
        public virtual string Name { get; protected set; }

        protected Snack()
        {

        }

        public Snack(string name)
        {
            Name = name;
        }
    }
}
