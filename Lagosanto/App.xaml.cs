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
             
           /*  IExpression expression = Parser.Parse("ART(DTS(A003,C084,O05),CPS(P279729033,4))");

             Context context = new Context();
             expression.Interpreter(context);
             Console.WriteLine(expression + " = " + context);*/

             loginView.Show();
             loginView.IsVisibleChanged += (_, _) =>
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
             };  
            
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
