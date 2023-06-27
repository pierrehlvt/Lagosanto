using System;
using System.Windows.Input;
using Lagosanto.Models;

namespace Lagosanto.ViewModels.DeskDepartment;

public class RecipeViewModel : ViewModelBase
{
    private int _id { get; set; }

    public int Id
    {
        get { return _id; }
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public ICommand LoadRecipeCommand { get; }

    public RecipeViewModel()
    {
        LoadRecipeCommand = new ViewModelCommand(ExecuteLoadRecipeCommand, CanExecuteLoadRecipeCommand);
    }

    private bool CanExecuteLoadRecipeCommand(object obj)
    {
        if (Id < 1)
        {
            return false;
        }

        return true;
    }

    private void ExecuteLoadRecipeCommand(object obj)
    {
        
    }
}