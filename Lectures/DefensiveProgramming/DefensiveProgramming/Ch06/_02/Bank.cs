using System;
using System.Collections.Generic;
using System.Text;

namespace Ch06._02
{
    public class Bank
    {
        private decimal _balnace;

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Only positive amounts can be deposited.", nameof(amount));

            _balnace += amount;
        }

        // 
        public void Deposit(PositiveDecimal amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            _balnace += amount;
        }
    }

    public class PositiveDecimal
    {
        private decimal _value;

        public PositiveDecimal(decimal value)
        {
            _value = value;
        }

        // 사용자 정의 변환 연산자
        // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
        public static implicit operator decimal(PositiveDecimal p) => 
            p._value;
    }
}
