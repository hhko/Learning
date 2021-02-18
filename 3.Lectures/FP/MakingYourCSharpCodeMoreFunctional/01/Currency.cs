using System;
using System.Diagnostics.CodeAnalysis;

namespace ChallengingTheObjectOrientedMindset 
{
    public sealed class Currency : IEquatable<Currency> 
    {
        public string Symbol { get; }

        public Currency (string symbol) 
        {
            Symbol = symbol;
        }

        public static Currency USD => new Currency ("USD");
        public static Currency EUR => new Currency ("EUR");
        public static Currency JPY => new Currency ("JPY");

        public override bool Equals (object obj) 
        {
            if (ReferenceEquals (null, obj))
                return false;

            if (ReferenceEquals (this, obj))
                return true;

            if (obj.GetType () != GetType ())
                return false;

            return Equals ((Currency) obj);
        }

        public bool Equals ([AllowNull] Currency other) 
        {
            if (ReferenceEquals (null, other))
                return false;

            if (ReferenceEquals (this, other))
                return true;

            return string.Equals (Symbol, other.Symbol);
        }

        public override int GetHashCode () =>
        Symbol != null ?
        Symbol.GetHashCode () :
            0;

        public static bool operator == (Currency a, Currency b) =>
            (ReferenceEquals (a, null) && ReferenceEquals (b, null)) ||
            (!ReferenceEquals (a, null) && a.Equals (b));

        public static bool operator != (Currency a, Currency b) =>
            !(a == b);
    }
}