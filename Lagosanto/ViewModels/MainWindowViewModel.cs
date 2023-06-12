
using Lagosanto.ViewModels.DeskDepartment;
using Lagosanto.ViewModels.FabricationDepartment;

namespace Lagosanto.ViewModels;

public class MainWindowViewModel: ViewModelBase
{
    private ViewModelBase _currentViewModel = null!;
    
    public ViewModelBase CurrentViewModel
    {
        get
        {
            return _currentViewModel;
        }
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
    
    public MainWindowViewModel()
    {
        ChangeViewModelDependingOnRole();
    }
    
    protected void ChangeViewModelDependingOnRole()
    {
        string role = "Desk";

        if (role == "Desk")
        {
            CurrentViewModel = new DeskViewModel();
        }

        if (role=="Fabrication")
        {
            CurrentViewModel = new FabricationViewModel();
        }
    }

}