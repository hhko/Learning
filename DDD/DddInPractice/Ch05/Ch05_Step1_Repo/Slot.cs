using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05_Step1_Repo
{
    public class Slot : Entity
    {
        // 추상화 시킨다.
        //public virtual Snack Snack { get; set; }
        //public virtual int Quantity { get; set; }
        //public virtual decimal Price { get; set; }
        public virtual SnackPile SnackPile { get; set; }

        public virtual SnackMachine SnackMachine { get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot()
        {

        }

        //public Slot(SnackMachine snackMachine, int position, Snack snack, int quantity, decimal price)
        //{
        //    SnackMachine = snackMachine;
        //    Position = position;
        //    Snack = snack;
        //    Quantity = quantity;
        //    Price = price;
        //}

        public Slot(SnackMachine snackMachine, int position)
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = new SnackPile(null, 0, 0m);
        }
    }
}
