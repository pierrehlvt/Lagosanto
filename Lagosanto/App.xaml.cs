using System;
using System.Collections.Generic;
using System.Windows;
using Lagosanto.Interpreter;
using Lagosanto.Services;
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
             
             InterpreterClient client = new InterpreterClient();
             client.ProcessInput("AT1(A003)CT(C084)CO(O05)ARTS[CP1(P279729033,4),CP2()]&AT2(A001)CT(C084)CO(O02)ARTS[CP1(A003,2),CP2(P815021753,3)]");

             Context context = client.Context;

             string articleCode = context.ArticleType;
             string categoryType = context.CategoryType;
             string operationType = context.OperationType;
             List<string> articles = context.Articles;
             List<(string, int)> articleQuantities = context.ArticleQuantities;
             
             
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
