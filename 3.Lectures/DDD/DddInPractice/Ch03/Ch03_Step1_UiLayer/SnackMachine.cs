using System;
using System.Linq;
using static Ch03_Step1_UiLayer.Money;

namespace Ch03_Step1_UiLayer
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
                {
                    Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
                };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
