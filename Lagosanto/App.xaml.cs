using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Lagosanto.Views;


namespace Lagosanto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (sender, e) =>
            {
                if (!loginView.IsVisible && loginView.IsLoaded)
                {
                    var mainView = new MainWindow();
                    mainView.Show();
                    loginView.Close();
                }
            };
            
        }
    }
}
