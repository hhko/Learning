using Ch07_Step1_DomainEvent.Common;
using Ch07_Step1_DomainEvent.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07_Step1_DomainEvent.Management
{
    public class HeadOffice : AggregateRoot
    {
        public virtual decimal Balance { get; protected set; }
        public virtual Money Cash { get; protected set; }

        public HeadOffice()
        {
            Cash = Money.None;
        }

        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }

        public virtual void UnloadCashFromSnackMachine(SnackMachine snackMachine)
        {
            Money money = snackMachine.UnloadMoney();
            Cash += money;
        }

        public virtual void LoadCashToAtm(Atm atm)
        {
            atm.LoadMoney(Cash);
            Cash = Money.None;
        }
    }
}
