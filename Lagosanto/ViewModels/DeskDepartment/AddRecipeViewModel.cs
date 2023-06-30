using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Lagosanto.Models;
using Lagosanto.Services;
using Lagosanto.Views.DeskDepartment;

namespace Lagosanto.ViewModels.DeskDepartment;

public class AddRecipeViewModel : ViewModelBase
{
    private DataProvider _provider = new();
    private List<Category> _categories;

    public List<Category> Categories
    {
        get { return _categories; }
        set
        {
            _categories = value;
            OnPropertyChanged(nameof(Categories));
        }
    }

    private Category _selectedCategory;

    public Category SelectedCategory
    {
        get { return _selectedCategory; }
        set
        {
            _selectedCategory = value;
            OnPropertyChanged(
                nameof(_selectedCategory));
        }
    }

    private List<Operation> _operations;

    public List<Operation> Operations
    {
        get { return _operations; }
        set
        {
            _operations = value;
            OnPropertyChanged(nameof(Operations));
        }
    }

    private Category _selectedOperations;

    public Category SelectedOperations
    {
        get { return _selectedOperations; }
        set
        {
            _selectedOperations = value;
            OnPropertyChanged(
                nameof(_selectedOperations));
        }
    }

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
    
    public ICommand ShowRecipeCommand { get; }

    public ICommand AddCodeArticleCommand { get; }

    private void LoadCategories()
    {
        var categories = _provider.GetAllCategories();
        Categories = new List<Category>(categories);
    }

    private void LoadOperations()
    {
        var operations = _provider.GetAllOperations();
        Operations = new List<Operation>(operations);
    }


    public AddRecipeViewModel()
    {
        AddRecipeCommand = new ViewModelCommand(ExecuteAddRecipeCommand, CanExecuteAddRecipeCommand);
        AddCodeArticleCommand = new ViewModelCommand(ExecuteAddCodeArticleCommand);
        ShowRecipeCommand= new ViewModelCommand(ExecuteShowRecipeCommand);

        LoadCategories();
        LoadOperations();
    }

    private void ExecuteShowRecipeCommand(object obj)
    {
        ShowRecipe  showRecipeWindow = new ShowRecipe();
        ShowRecipeViewModel showRecipeWindowViewModel = new ShowRecipeViewModel();
        showRecipeWindow.DataContext = showRecipeWindowViewModel;
        showRecipeWindow.ShowDialog();
    }


    private void ExecuteAddCodeArticleCommand(object obj)
    {
        CodeArticleView codeArticleWindow = new CodeArticleView();
        CodeArticleViewModel codeArticleWindowViewModel = new CodeArticleViewModel();
        codeArticleWindow.DataContext = codeArticleWindowViewModel;
        Recipe += codeArticleWindow.ShowDialog() == false ? codeArticleWindowViewModel.CodeArticle : "";
    }

    private void ExecuteAddRecipeCommand(object obj)
    {
    }

    private bool CanExecuteAddRecipeCommand(object obj)
    {
        return false;
    }
}