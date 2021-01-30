using System;
using System.Collections.Generic;
using System.Text;
using WpfCommon;

namespace Ch03_Step2_ApplicaionService.Desktop
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;

        public override string Caption => "Snack Machine";

        //public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
        public Money MoneyInTransaction => _snackMachine.MoneyInTransaction;
        public Money MoneyInside => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;

        private string _message = "";
        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                Notify();
            }
        }

        public Command InsertCentCommand { get; private set; }
        public Command InsertTenCentCommand { get; private set; }
        public Command InsertQuarterCommand { get; private set; }
        public Command InsertDollarCommand { get; private set; }
        public Command InsertFiveDollarCommand { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }
        public Command ReturnMoneyCommand { get; private set; }
        public Command BuySnackCommand { get; private set; }

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;

            InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
            InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
            InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
            InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command(() => BuySnack());
        }

        private void BuySnack()
        {
            _snackMachine.BuySnack();
            //using (ISession session = SessionFactory.OpenSession())
            //using (ITransaction transaction = session.BeginTransaction())
            //{
            //    session.SaveOrUpdate(_snackMachine);
            //    transaction.Commit();
            //}
            NotifyClient("You have bought a snack");
        }

        private void ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            NotifyClient("Money was returned");
        }

        private void InsertMoney(Money coinOrNote)
        {
            _snackMachine.InsertMoney(coinOrNote);
            NotifyClient("You have inserted: " + coinOrNote);
        }

        private void NotifyClient(string message)
        {
            Message = message;
            Notify(nameof(MoneyInTransaction));
            Notify(nameof(MoneyInside));
        }
    }
}
