using System.Collections.Generic;
using System.Windows.Input;
using Lagosanto.Interpreter;
using Lagosanto.Views.DeskDepartment;

namespace Lagosanto.ViewModels.DeskDepartment;

public class AddRecipeViewModel : ViewModelBase
{

    private string _newRecipe = "";

    public string Recipe
    {
        get { return _newRecipe; }
        set
        {
            _newRecipe = value;
            OnPropertyChanged(nameof(Recipe));
        }
    }
    
    public ICommand AddRecipeCommand { get; }
    
    public ICommand AddCodeArticleCommand { get; }

    public AddRecipeViewModel()
    {
        AddRecipeCommand = new ViewModelCommand(ExecuteAddRecipeCommand);
        AddCodeArticleCommand = new ViewModelCommand(ExecuteAddCodeArticleCommand);
    }
    
    private void ExecuteAddCodeArticleCommand(object obj)
    {
        CodeArticleView codeArticleWindow = new CodeArticleView();
        CodeArticleViewModel codeArticleWindowViewModel = new CodeArticleViewModel();
        codeArticleWindow.DataContext = codeArticleWindowViewModel;
        
        Recipe += codeArticleWindow.ShowDialog() == true ? codeArticleWindowViewModel.CodeArticle : "";
    }
    
    private void ExecuteAddRecipeCommand(object obj)
    {

        
    }
}