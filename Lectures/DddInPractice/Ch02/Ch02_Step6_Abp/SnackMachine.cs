using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using static Ch02_Step6_Abp.Money;

namespace Ch02_Step6_Abp
{
    public class SnackMachine : Entity<Guid>
    {
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public SnackMachine(Guid id)
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
