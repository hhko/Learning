using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05_Step1_Repo
{
    //public class Snack : Entity
    public class Snack : AggregateRoot
    {
        //
        // NULL 처리를 위한 명시적 타입을 정의한다.
        //
        public static readonly Snack None = new Snack(0, "None");
        
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");
        public static readonly Snack Soda = new Snack(2, "Soda");
        public static readonly Snack Gum = new Snack(3, "Gum");

        public virtual string Name { get; protected set; }

        protected Snack()
        {

        }

        public Snack(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
