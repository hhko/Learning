using System;

namespace Ch03._07
{
    public class Money
    {
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money ADd(Money other)
        {
            if (!CanAdd(other))
                throw new ArgumentException();

            return null;
        }

        public bool CanAdd(Money other) => Currency == other.Currency;

        public MoneyBag Mix(Money other)
        {
            return null;
        }

        public MoneyBag Mix(MoneyBag other)
        {
            return null;
        }

        public MoneyBag ToMoneyBag()
        {
            return null;
        }
    }
}
