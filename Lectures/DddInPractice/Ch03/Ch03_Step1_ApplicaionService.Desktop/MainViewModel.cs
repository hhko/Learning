using System;
using System.Collections.Generic;
using System.Text;
using WpfCommon;
using WpfCommon.Utils;

namespace Ch03_Step1_ApplicaionService.Desktop
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            //SnackMachine snackMachine;
            //using (ISession session = SessionFactory.OpenSession())
            //{
            //    snackMachine = session.Get<SnackMachine>(1L);
            //}
            SnackMachine snackMachine = new SnackMachine();
            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
