using System;

namespace Ch02_Step3_EntityAndValueObject
{
    public sealed class SnackMachine : Entity
    {
        // 스낵머신 기계에 있는 돈
        public Money MoneyInside { get; private set; }

        // 고객이 스택머신에 투입한 돈
        //
        // 왜 돈을 구분하는가?
        //  > 고객이 돈을 반환 요청할 때 투입한 돈을 구분할 수 있어야 하기 때문이다. 
        public Money MoneyInTransaction { get; private set; }

        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            // 아직 제공하지 않는다.
            //MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            // 아직 제공하지 않는다.
            //MoneyInTransaction = 0;
        }
    }
}
