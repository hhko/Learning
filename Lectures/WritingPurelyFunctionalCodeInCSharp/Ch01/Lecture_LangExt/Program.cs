using LanguageExt;
using System;

namespace Lecture_LangExt
{
    [Record]
    public partial struct Currency
    {
        public readonly string Symbol;
    }

    [Record]
    public partial struct Amount
    {
        public readonly decimal Value;
        public readonly Currency Currency;
    }

    [Union]
    public interface IMoney
    {
        IMoney Cash(decimal value, Currency currency);
        IMoney Gift(decimal value, Currency currency, DateTime validBefore);
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

            var (final, added) = Add(Cash.New(2020, new Currency("USD")), Amount.New(10, new Currency("USD")), DateTime.Now);

            var x1 = new Cash(1, new Currency("USD"));
            var x2 = x1.With(Value: 6);     // Immutable
        }
    }
}
