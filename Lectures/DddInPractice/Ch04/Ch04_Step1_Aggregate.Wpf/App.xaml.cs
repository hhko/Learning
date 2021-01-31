using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ch04_Step1_Aggregate.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //
            // DB 접속
            //
            Initer.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=True;");
        }
    }
}
