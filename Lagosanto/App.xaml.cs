using System;
using System.Windows;
using Lagosanto.ViewModels;
using Lagosanto.ViewModels.DeskDepartment;
using Lagosanto.ViewModels.FabricationDepartment;
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
             DatabaseHelper databaseHelper = new DatabaseHelper();

             string article = "ART(DTS((A003,C084,O05)),CPS((P279729033,C086,O08)))," +
                              "ART(DTS((A005,C084,006)),CPS((A003,C084,O05,P279729033,C086,O08)))";

             Current.MainWindow = loginView;
             loginView.Show();
          /*   loginView.IsVisibleChanged += (_, _) =>
             {
                 if (loginView.IsVisible || !loginView.IsLoaded) return;
                 {
                     try{
                         Dispatcher.BeginInvoke(new Action(() =>
                         {
                             Window mainView = new MainWindowView();
                             mainView.DataContext = DependencyInjection().GetRequiredService<MainWindowViewModel>();
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
             };  */
            
        }

        private ServiceProvider DependencyInjection()
        {
            var services = new ServiceCollection();
            services.AddSingleton<LoginWindowView>();
            services.AddSingleton<AddRecipeViewModel>();
            services.AddSingleton<RecipeViewModel>();
            services.AddSingleton<AddRecipeViewModel>();
            services.AddSingleton<FabricationViewModel>();
            services.AddSingleton<ProductionViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider; 
        }
        
    }
}
