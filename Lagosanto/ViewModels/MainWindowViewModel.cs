using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Lagosanto.ViewModels;

public class MainWindowViewModel: ViewModelBase
{
    private ViewModelBase _currentViewModel;
    
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
        string role = "Admin";

        if (role == "Admin")
        {
            CurrentViewModel = new DeskViewModel();
        }

        if (role=="")
        {
            
        }
    }

}