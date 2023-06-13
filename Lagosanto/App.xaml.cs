using System;
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
             {
                 Dispatcher.BeginInvoke(new Action(() =>
                 {
                     Window mainView = new MainWindowView();
                     mainView.Show();
                     loginView.Close();
                 }));
             };  
            
        }
        
    }
}
