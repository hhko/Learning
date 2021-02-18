using System;

namespace ChallengingTheObjectOrientedMindset 
{
    public class GiftCard : FixedMoney 
    {
        public Date ValidBefore { get; }

        public GiftCard (Currency currency, decimal amount, Date validBefore) : base (currency, amount) 
        {
            if (validBefore == null)
                throw new ArgumentException (nameof (validBefore));

            ValidBefore = validBefore;
        }

        public override decimal Withdraw (Currency currency, decimal amount) 
        {
            if (ValidBefore.CompareTo (DateTime.Now) <= 0)
                return 0;

            return base.Withdraw (currency, amount);
        }
    }
}