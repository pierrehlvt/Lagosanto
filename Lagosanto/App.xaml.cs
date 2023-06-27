using System;
using System.Windows;
using Lagosanto.ViewModels;
using Lagosanto.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Lagosanto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App: Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            
             LoginWindowView loginView = new LoginWindowView();
             ServiceProvider serviceProvider = DependencyInjection();
             DatabaseHelper databaseHelper = new DatabaseHelper();
             loginView.Show();
             loginView.IsVisibleChanged += (_, _) =>
             {
                 if (loginView.IsVisible || !loginView.IsLoaded) return;
                 {
                     try{
                         Dispatcher.BeginInvoke(new Action(() =>
                         {
                             Window mainView = new MainWindowView();
                             mainView.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
                             mainView.Show();
                             loginView.Close();
                         }));
                     }
                     catch (Exception exception)
                     {
                         Console.WriteLine(exception);
                         throw;
                     }
                 }
             };  
            
        }

        private ServiceProvider DependencyInjection()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<MainWindowViewModel>();
            return services.BuildServiceProvider();
        }
        
    }
}
