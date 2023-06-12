using System.Windows;
using System.Windows.Input;

namespace Lagosanto.ViewModels.DeskDepartment;

public class RecipeViewModel: ViewModelBase
{
    public ICommand TestCommand { get;}
    public RecipeViewModel()
    {
        TestCommand = new ViewModelCommand(ExecuteTestCommand);
        
    }

    private void ExecuteTestCommand(object obj)
    {
        MessageBox.Show("Button test", "Alerte", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}