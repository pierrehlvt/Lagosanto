using System.Windows.Input;
using FontAwesome.Sharp;

namespace Lagosanto.ViewModels.DeskDepartment;

public class DeskViewModel: ViewModelBase
{
    
    private ViewModelBase _currentChildViewModel = null!;
    private string _caption = null!;
    private IconChar _iconChar;
    
    public string Caption
    {
        get
        {
            return _caption;
        }
        set
        {
            _caption = value;
            OnPropertyChanged(nameof(Caption));
        }
    }

    public IconChar IconChar
    {
        get
        {
            return _iconChar;
        }
        set
        {
            _iconChar = value;
            OnPropertyChanged(nameof(IconChar));
        }
    }
    
    
    public ViewModelBase CurrentChildViewModel
    {
        get
        {
            return _currentChildViewModel;
        }
        set
        {
            _currentChildViewModel = value;
            OnPropertyChanged(nameof(CurrentChildViewModel));
        }
    }
    
    public ICommand ShowAddRecipeViewCommand { get;}
    public ICommand ShowRecipeViewCommand { get;}

    public DeskViewModel()
    {
        ShowAddRecipeViewCommand = new ViewModelCommand(ExecuteShowAddRecipeViewCommand);
        ShowRecipeViewCommand = new ViewModelCommand(ExecuteShowRecipeViewCommand);

        ExecuteShowRecipeViewCommand(null!);
        
    }

    private void ExecuteShowRecipeViewCommand(object obj)
    {
        CurrentChildViewModel = new RecipeViewModel();
        Caption = "Recettes";
        IconChar = IconChar.MagnifyingGlass;
    }

    private void ExecuteShowAddRecipeViewCommand(object obj)
    {
        CurrentChildViewModel = new AddRecipeViewModel();
        Caption = "Ajouter une recette";
        IconChar = IconChar.Plus;
    }
}