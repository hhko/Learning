using System;
using System.Collections.Generic;
using System.Linq;
using static Ch04_Step1_Aggregate.Money;

namespace Ch04_Step1_Aggregate
{
    // 1. sealed
    // 2. virtual
    // 3. private -> protected
    // 4. private constructor
    // 5. Entity 적용 
    // 6. Entity Equal Type : NHibernateProxyHelper.GetClassWithoutInitializingProxy

    //public sealed class SnackMachine : Entity
    //public class SnackMachine : Entity
    public class SnackMachine : AggregateRoot
    {
        public virtual Money MoneyInside { get; protected set; }
        public virtual Money MoneyInTransaction { get; protected set; }

        //
        // 문제점
        //
        // - IList가 노출되면 Slot은 3개만 존재한다(불변 규칙)을 위반할 수 있다.  
        // - Aggregate Root을 거치지 않고 가변 객체 Slot `Entity`가 노출된다.
        //   가변 도메인 객체가 노출되면 불변 규칙을 준수할 수 없다.
        public virtual IList<Slot> Slots { get; set; }

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = None;

            Slots = new List<Slot>
            {
                new Slot(this, 1, null, 0, 0m),
                new Slot(this, 2, null, 0, 0m),
                new Slot(this, 3, null, 0, 0m)
            };
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
                {
                    Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
                };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public virtual void BuySnack(int position)
        {
            Slot slot = Slots.Single(x => x.Position == position);
            slot.Quantity--;

            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }

        public virtual void LoadSnacks(int position, Snack snack, int quantity, decimal price)
        {
            Slot slot = Slots.Single(x => x.Position == position);
            slot.Snack = snack;
            slot.Quantity = quantity;
            slot.Price = price;
        }
    }
}
