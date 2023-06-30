
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Lagosanto.Models;
using Lagosanto.Repositories;
using Lagosanto.Repositories.Interfaces;
using Lagosanto.Services;
using Lagosanto.ViewModels.DeskDepartment;
using Lagosanto.ViewModels.FabricationDepartment;
using Lagosanto.Views;

namespace Lagosanto.ViewModels;

public class MainWindowViewModel: ViewModelBase
{
    private ViewModelBase _currentViewModel = null!;
    private User _user;
    private IUserRepository _userRepository;

    public User User
    {
        get
        {
            return _user;
        }
        set
        {
            _user = value;
            OnPropertyChanged(nameof(User));
        }
    }

    public ICommand LogoutCommand { get; }

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
        LogoutCommand = new ViewModelCommand(ExecuteLogoutCommand);
        _userRepository = new UserRepository();
        ChangeViewModelDependingOnRole();
    }

    private void ExecuteLogoutCommand(object obj)
    {
        // Create a new instance of LoginWindowView and set it as the MainWindow
        LoginWindowView loginView = new LoginWindowView();
        LoginViewModel loginViewModel = new LoginViewModel();
        loginView.DataContext = loginViewModel;
        loginView.Show();
        
        if (Application.Current.MainWindow != null)
        {
            Application.Current.MainWindow.Close();
        }
        Application.Current.MainWindow = loginView;
    }
    protected void ChangeViewModelDependingOnRole()
    {
        User user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
        User = user;

        if (user.Role == Role.ROLE_DESK)
        {
            CurrentViewModel = new DeskViewModel();
        }

        if (user.Role==Role.ROLE_FABRICATION)
        {
            CurrentViewModel = new FabricationViewModel();
        }
    }

}