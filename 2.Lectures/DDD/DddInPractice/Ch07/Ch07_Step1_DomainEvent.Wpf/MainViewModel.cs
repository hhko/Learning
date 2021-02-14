using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using WpfCommon;
using WpfCommon.Utils;

namespace Ch07_Step1_DomainEvent.Wpf
{
    public class MainViewModel : ViewModel
    {
        //public MainViewModel()
        //{
        //    //
        //    // DB에서 데이터 복원
        //    //
        //    SnackMachine snackMachine;
        //    using (ISession session = SessionFactory.OpenSession())
        //    {
        //        snackMachine = session.Get<SnackMachine>(1L);
        //    }
        //    //SnackMachine snackMachine = new SnackMachine();
        //    var viewModel = new SnackMachineViewModel(snackMachine);
        //    _dialogService.ShowDialog(viewModel);
        //}

        public Command ShowSnackMachineCommand { get; private set; }
        public Command ShowAtmCommand { get; private set; }

        public MainViewModel()
        {
            ShowSnackMachineCommand = new Command(ShowSnackMachine);
            ShowAtmCommand = new Command(ShowAtm);
        }

        private void ShowSnackMachine()
        {
            SnackMachine snackMachine = new SnackMachineRepository().GetById(1);
            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }

        private void ShowAtm()
        {
            Atm atm = new AtmRepository().GetById(1);
            var viewModel = new AtmViewModel(atm);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
