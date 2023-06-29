
using System.Threading;
using Lagosanto.Models;
using Lagosanto.Repositories;
using Lagosanto.Repositories.Interfaces;
using Lagosanto.Services;
using Lagosanto.ViewModels.DeskDepartment;
using Lagosanto.ViewModels.FabricationDepartment;

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
        _userRepository = new UserRepository();
        ChangeViewModelDependingOnRole();
        ProductionService productionService = new ProductionService();
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