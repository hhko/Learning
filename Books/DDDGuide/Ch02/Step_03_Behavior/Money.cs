using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step_03_Behavior
{
    public class Money : IEquatable<Money>
    {
        private readonly decimal _amount;
        private readonly string _currency;

        public Money(decimal amount, string currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public bool Equals([AllowNull] Money other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return _amount == other._amount
                && string.Equals(_currency, other._currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_amount, _currency);
        }

        public Money Add(Money arg)
        {
            if (arg == null)
                throw new ArgumentNullException(nameof(arg));
            if (_currency != arg._currency)
                throw new ArgumentException($"화폐 단위가 다름 (this:{_currency}, arg:{arg._currency})", nameof(arg));

            return new Money(_amount + arg._amount, _currency);
        }
    }
}
