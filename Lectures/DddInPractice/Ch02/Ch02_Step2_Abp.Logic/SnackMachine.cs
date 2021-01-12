using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using static Ch02_Step2_Abp.Logic.Money;

namespace Ch02_Step2_Abp.Logic
{
    public class SnackMachine : Entity<Guid>
    {
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public SnackMachine(Guid id)
            : base(id)
        {

        }

        public void InsertMoney(Money money)
        {
            var coninsAndNotes = new Money[]
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };

            if (!coninsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
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
