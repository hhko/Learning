using System.Windows;

namespace Ch05_Step1_Repo.Wpf
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
