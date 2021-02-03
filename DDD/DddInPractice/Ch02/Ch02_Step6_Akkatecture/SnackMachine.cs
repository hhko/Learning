using Akkatecture.Core;
using Akkatecture.Entities;
using Akkatecture.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Ch02_Step6_Akkatecture.Money;

namespace Ch02_Step6_Akkatecture
{
    public class SnackMachine : Entity<SnackMachineId>
    {
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public SnackMachine(SnackMachineId id)
            : base(id)
        {

        }

        public void InsertMoney(Money coinOrNote)
        {
            var coninsAndNotes = new Money[]
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };

            if (!coninsAndNotes.Contains(coinOrNote))
                throw new InvalidOperationException();

            MoneyInTransaction += coinOrNote;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
