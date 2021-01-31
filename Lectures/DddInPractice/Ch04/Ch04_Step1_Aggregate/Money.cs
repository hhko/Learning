using System;

namespace Ch04_Step1_Aggregate
{
    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

        public int OneCentCount { get; private set; }           //  0.01
        public int TenCentCount { get; private set; }           //  0.10
        public int QuarterCount { get; private set; }           //  0.25
        public int OneDollarCount { get; private set; }         //  1.00
        public int FiveDollarCount { get; private set; }        //  5.00
        public int TwentyDollarCount { get; private set; }      // 20.00

        public decimal Amount =>
            OneCentCount * 0.01m +
            TenCentCount * 0.10m +
            QuarterCount * 0.25m +
            OneDollarCount +
            FiveDollarCount * 5 +
            TwentyDollarCount * 20;

        private Money()
        {

        }

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            if (oneCentCount < 0)
                throw new InvalidOperationException(nameof(oneCentCount));
            if (tenCentCount < 0)
                throw new InvalidOperationException(nameof(tenCentCount));
            if (quarterCount < 0)
                throw new InvalidOperationException(nameof(quarterCount));
            if (oneDollarCount < 0)
                throw new InvalidOperationException(nameof(oneDollarCount));
            if (fiveDollarCount < 0)
                throw new InvalidOperationException(nameof(fiveDollarCount));
            if (twentyDollarCount < 0)
                throw new InvalidOperationException(nameof(twentyDollarCount));

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount);
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount);
        }

        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                && TenCentCount == other.TenCentCount
                && QuarterCount == other.QuarterCount
                && OneDollarCount == other.OneDollarCount
                && FiveDollarCount == other.FiveDollarCount
                && TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }

        public override string ToString()
        {
            if (Amount < 1)
            {
                // 동전(Coin)
                return "¢" + (Amount * 100).ToString("0");
            }
            else
            {
                // 지폐(Note)
                return "$" + Amount.ToString("0.00");
            }
        }
    }
}
