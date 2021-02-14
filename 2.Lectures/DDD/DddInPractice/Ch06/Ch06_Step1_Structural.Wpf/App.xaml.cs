using Ch06_Step1_Structural.Utils;
using System.Windows;

namespace Ch06_Step1_Structural.Wpf
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
