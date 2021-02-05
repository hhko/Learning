using System;
using System.Collections.Generic;
using System.Linq;
using static Ch04_Step3_MissingVoc.Money;

namespace Ch04_Step3_MissingVoc
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

        //
        // 투입한 금액 반환 vs. 투입한 "동일한" 금액 반환
        //                     - 잔액을 최우선적으로 보관한다.
        //                     - 투입한 동일한 단위로 반환할 필요가 없다(동일한 금액이면 된다).
        //
        //public virtual Money MoneyInTransaction { get; protected set; }
        public virtual decimal MoneyInTransaction { get; protected set; }

        //public virtual IList<Slot> Slots { get; protected set; }
        protected virtual IList<Slot> Slots { get; }

        public SnackMachine()
        {
            MoneyInside = None;
            //MoneyInTransaction = None;
            MoneyInTransaction = 0;

            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

        public virtual SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
                {
                    Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
                };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            //MoneyInTransaction += money;
            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public virtual void ReturnMoney()
        {
            ////MoneyInTransaction = None;
            //MoneyInTransaction = 0;

            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public virtual void BuySnack(int position)
        {
            Slot slot = GetSlot(position);
            //if (slot.SnackPile.Price > MoneyInTransaction.Amount)
            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();

            //
            // 불변 값 객체
            //
            //slot.Quantity--;
            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)
                throw new InvalidOperationException();

            MoneyInside -= change;

            //MoneyInside += MoneyInTransaction;
            //MoneyInTransaction = None;
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
