using System;
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

    public class SnackMachine : Entity
    //public sealed class SnackMachine : Entity
    {
        public virtual Money MoneyInside { get; protected set; } = None;
        public virtual Money MoneyInTransaction { get; protected set; } = None;

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

        public virtual void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
