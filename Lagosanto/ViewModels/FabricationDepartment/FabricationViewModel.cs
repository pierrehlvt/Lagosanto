using System.Windows.Input;
using FontAwesome.Sharp;

namespace Lagosanto.ViewModels.FabricationDepartment;

public class FabricationViewModel: ViewModelBase
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

    public ICommand ShowProductionViewCommand { get;}

    public FabricationViewModel()
    {
        ShowProductionViewCommand = new ViewModelCommand(ExecuteShowProductionViewCommand);
        ExecuteShowProductionViewCommand(null!);
    }
    
    private void ExecuteShowProductionViewCommand(object obj)
    {
        CurrentChildViewModel = new ProductionViewModel();
        Caption = "Production";
        IconChar = IconChar.Gear;
    }
    
}