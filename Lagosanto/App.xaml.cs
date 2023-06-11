using System.Windows;
using Lagosanto.Views;


namespace Lagosanto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            
             var loginView = new LoginWindowView();
             loginView.Show();
             loginView.IsVisibleChanged += (sender, e) =>
             {//provoque un lag à la fermeture de la fenetre
                 if (loginView is not { IsVisible: false, IsLoaded: true }) return;
                 var mainView = new MainWindowView();
                 mainView.Show();
                 loginView.Close();
             };  
           



        }
    }
}
