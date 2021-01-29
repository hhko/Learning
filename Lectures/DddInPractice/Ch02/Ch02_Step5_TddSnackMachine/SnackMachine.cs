using System;
using System.Linq;
using static Ch02_Step5_TddSnackMachine.Money;

namespace Ch02_Step5_TddSnackMachine
{
    public sealed class SnackMachine : Entity
    {
        //
        // 단위 테스트 발굴 : 객체를 초기화한다.
        // 

        // 스낵머신 기계에 있는 돈
        public Money MoneyInside { get; set; } = None;

        // 고객이 스택머신에 투입한 돈
        //
        // 왜 돈을 구분하는가?
        //  > 고객이 돈을 반환 요청할 때 투입한 돈을 구분할 수 있어야 하기 때문이다. 
        public Money MoneyInTransaction { get; set; } = None;

        public void InsertMoney(Money coinOrNote)
        {
            //
            // 단위 테스트 발굴 : 유요한 입력을 체크한다.
            // 
            Money[] coinsAndNotes =
                {
                    Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
                };
            if (!coinsAndNotes.Contains(coinOrNote))
                throw new InvalidOperationException();

            MoneyInTransaction += coinOrNote;
        }

        public void ReturnMoney()
        {
            //
            // 단위 테스트 발굴 : 불변을 단순화하고 더 명확히 기술한다.
            // 

            // 아직 제공하지 않는다.
            //MoneyInTransaction = 0;
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            // 아직 제공하지 않는다.
            //MoneyInTransaction = 0;
            MoneyInTransaction = None;
        }
    }
}
