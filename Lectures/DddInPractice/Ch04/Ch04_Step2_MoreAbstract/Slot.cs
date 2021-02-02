using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04_Step2_MoreAbstract
{
    public class Slot : Entity
    {
        public virtual Snack Snack { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual SnackMachine SnackMachine { get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot()
        {

        }

        public Slot(SnackMachine snackMachine, int position, Snack snack, int quantity, decimal price)
        {
            SnackMachine = snackMachine;
            Position = position;
            Snack = snack;
            Quantity = quantity;
            Price = price;
        }
    }
}
