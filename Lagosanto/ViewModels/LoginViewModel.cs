using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Lagosanto.Repositories;
using Lagosanto.Repositories.Interfaces;

namespace Lagosanto.ViewModels;

public class LoginViewModel: ViewModelBase
{
    
    private string _username="";
    private SecureString _password;
    private string _errorMessage = null!;
    private bool _isViewVisible=true;
    private IUserRepository userRepository;

    public bool IsViewVisible
    {
        get
        {
            return _isViewVisible;
        }
        set
        {
            _isViewVisible = value;
            OnPropertyChanged(nameof(IsViewVisible));
        }
    }
    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }
    
    public SecureString Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    
    public string ErrorMessage
    {
        get
        {
            return _errorMessage;
        }
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
    
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        userRepository = new UserRepository();
        LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
    }

    private bool CanExecuteLoginCommand(object obj)
    {
        if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || _password.Length < 3)
        {
           return false;
        }

        return true;
    }

    public void ExecuteLoginCommand(object obj)
    {
        var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
        if (isValidUser)
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity(Username), null);
            IsViewVisible = false;
        }
        else
        {
            ErrorMessage = "* Utilisateur ou mot de passe invalide";
        }
    }
    
}