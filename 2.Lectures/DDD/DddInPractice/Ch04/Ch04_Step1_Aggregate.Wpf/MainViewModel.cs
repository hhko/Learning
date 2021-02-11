using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using WpfCommon;
using WpfCommon.Utils;

namespace Ch04_Step1_Aggregate.Wpf
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            //
            // DB에서 데이터 복원
            //
            SnackMachine snackMachine;
            using (ISession session = SessionFactory.OpenSession())
            {
                snackMachine = session.Get<SnackMachine>(1L);
            }
            //SnackMachine snackMachine = new SnackMachine();
            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
