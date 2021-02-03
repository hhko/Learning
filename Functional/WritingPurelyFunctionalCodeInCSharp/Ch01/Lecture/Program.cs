using System;

namespace Lecture
{
    // Marker Interface
    interface IMoney { }
    
    class Currency
    {
        public string Symbol { get; }

        public Currency(string symbol)
        {
            Symbol = !string.IsNullOrWhiteSpace(symbol)
                ? symbol
                : throw new ArgumentException(nameof(symbol));
        }
    }

    class Amount
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public Amount(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency
                ?? throw new ArgumentNullException(nameof(currency));
        }
    }

    class Cash : IMoney
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public Cash(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency
                ?? throw new ArgumentNullException(nameof(currency));
        }
    }

    class Gift : IMoney
    {
        public decimal Value { get; }
        public Currency Currency { get; }
        public DateTime ValidBefore { get; }

        public Gift(decimal value, Currency currency, DateTime validBefore)
        {
            Value = value;
            Currency = currency
                ?? throw new ArgumentNullException(nameof(currency));
            ValidBefore = validBefore;
        }
    }

    class Program
    {
        static (IMoney final, Amount added) Add(IMoney money, Amount amount, DateTime at)
        {
            return money switch
            {
                Cash cash when amount.Currency == cash.Currency => (new Cash(cash.Value + amount.Value, cash.Currency), amount),
                Cash _ => (money, new Amount(0, amount.Currency)),

                Gift gift when at < gift.ValidBefore && amount.Currency == gift.Currency => (new Gift(gift.Value + amount.Value, gift.Currency, gift.ValidBefore), amount),
                Gift _ => (money, new Amount(0, amount.Currency)),

                //
                // Discriminated Unions 타입(IMoney : Cash, Gift) 경우의 수를 인식하지 못한다.
                // 모든 경우의 수를 제어하기 위해 '_'을 컴퍼일러는 요구한다(경고).
                //
                // Warning CS8509 
                //   The switch expression does not handle all possible values of its input type(it is not exhaustive). 
                //   For example, the pattern '_' is not covered.
                _ => throw new ArgumentException()
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
