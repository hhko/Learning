using System;

namespace Ch03._07
{
    public class PositiveMoney : Money
    {
        public PositiveMoney(decimal amount, Currency currency)
            : base(amount, currency)
        {
            if (amount <= 0)
                throw new ArgumentException();
        }
    }
}
