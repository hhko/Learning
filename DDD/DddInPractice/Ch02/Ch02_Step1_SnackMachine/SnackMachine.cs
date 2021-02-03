using System;

namespace Ch02_Step1_SnackMachine
{
    public sealed class SnackMachine
    {
        // 스낵머신 기계에 있는 돈
        public int OneCentCount { get; set; }
        public int TenCentCount { get; set; }
        public int QuarterCount { get; set; }
        public int OneDollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TwentyDollarCount { get; set; }

        // 고객이 스택머신에 투입한 돈
        //
        // 왜 돈을 구분하는가?
        //  > 고객이 돈을 반환 요청할 때 투입한 돈을 구분할 수 있어야 하기 때문이다. 
        public int OneCentCountInTransaction { get; set; }
        public int TenCentCountInTransaction { get; set; }
        public int QuarterCountInTransaction { get; set; }
        public int OneDollarCountInTransaction { get; set; }
        public int FiveDollarCountInTransaction { get; set; }
        public int TwentyDollarCountInTransaction { get; set; }

        public void InsertMoney(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            OneCentCountInTransaction += oneCentCount;
            TenCentCountInTransaction += tenCentCount;
            QuarterCountInTransaction += quarterCount;
            OneDollarCountInTransaction += oneDollarCount;
            FiveDollarCountInTransaction += fiveDollarCount;
            TwentyDollarCountInTransaction += twentyDollarCount;
        }

        public void ReturnMoney()
        {
            OneCentCountInTransaction = 0;
            TenCentCountInTransaction = 0;
            QuarterCountInTransaction = 0;
            OneDollarCountInTransaction = 0;
            FiveDollarCountInTransaction = 0;
            TwentyDollarCountInTransaction = 0;
        }

        public void BuySnack()
        {
            OneCentCount += OneCentCountInTransaction;
            TenCentCount += TenCentCountInTransaction;
            QuarterCount += QuarterCountInTransaction;
            OneDollarCount += OneDollarCountInTransaction;
            FiveDollarCount += FiveDollarCountInTransaction;
            TwentyDollarCount += TwentyDollarCountInTransaction;

            OneCentCountInTransaction = 0;
            TenCentCountInTransaction = 0;
            QuarterCountInTransaction = 0;
            OneDollarCountInTransaction = 0;
            FiveDollarCountInTransaction = 0;
            TwentyDollarCountInTransaction = 0;
        }
    }
}
