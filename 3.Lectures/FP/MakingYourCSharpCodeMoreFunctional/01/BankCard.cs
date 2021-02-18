using System;
namespace ChallengingTheObjectOrientedMindset 
{
    public class BankCard : Money 
    {
        public Month ValidBefore { get; }

        public BankCard (Month validBefore) 
        {
            if (validBefore == null)
                throw new ArgumentException (nameof (validBefore));

            ValidBefore = validBefore;
        }

        public override decimal Withdraw (Currency currency, decimal amount) 
        {
            if (ValidBefore.CompareTo (DateTime.Now) <= 0)
                return 0;

            return amount;
        }
    }
}