using Ch06_Step2_Atm.SharedBase;
using Ch06_Step2_Atm.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ch06_Step2_Atm.SharedKernel.Money;

namespace Ch06_Step2_Atm
{
    public class Atm : AggregateRoot
    {
        private const decimal CommissionRate = 0.01m;

        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyCharged { get; protected set; }

        public Atm()
        {
            MoneyInside = None;
        }

        public virtual string CanTakeMoney(decimal amount)
        {
            if (amount <= 0m)
                return "Invalid amount";

            if (amount > MoneyInside.Amount)
                return "Not enough money";

            if (!MoneyInside.CanAllocate(amount))
                return "Not enough change";

            return string.Empty;
        }

        public virtual void TakeMoney(decimal amount)
        {
            if (CanTakeMoney(amount) != string.Empty)
                throw new InvalidOperationException();

            Money output = MoneyInside.Allocate(amount);
            MoneyInside -= output;

            decimal amountWithCommission = CaluculateAmountWithCommission(amount);
            MoneyCharged += amountWithCommission;
        }

        public virtual decimal CaluculateAmountWithCommission(decimal amount)
        {
            decimal commission = amount * CommissionRate;
            decimal lessThanCent = commission % 0.01m;

            if (lessThanCent > 0)
            {
                commission = commission - lessThanCent + 0.01m;
            }

            return amount + commission;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
