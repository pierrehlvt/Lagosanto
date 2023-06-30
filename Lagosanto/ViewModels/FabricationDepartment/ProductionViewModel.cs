using System.Windows.Input;
using Lagosanto.Services;

namespace Lagosanto.ViewModels.FabricationDepartment;

public class ProductionViewModel: ViewModelBase
{
    private int _recipeId { get; set; }
    
    private int _quantity { get; set; }
    
    public int RecipeId
    {
        get
        {
            return _recipeId;
        }
        set
        {
            _recipeId = value;
            OnPropertyChanged(nameof(RecipeId));
        }
    }
    
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }
    
    public ICommand LoadProductionCommand { get;}
    
    public ProductionViewModel()
    {
        LoadProductionCommand = new ViewModelCommand(ExecuteProductionCommand,CanProductionCommand);
    }

    private bool CanProductionCommand(object obj)
    {
        if (RecipeId < 1 ||  Quantity < 1)
        {
            
            return false;
        }

        return true;
        
    }

    private void ExecuteProductionCommand(object obj)
    {
        ProductionService.LaunchProduction(RecipeId,Quantity);
    }
}