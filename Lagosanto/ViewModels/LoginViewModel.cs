using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Lagosanto.ViewModels;

public class LoginViewModel: ViewModelBase
{
    
    private string _username="";
    private SecureString _password;
    private string _errorMessage;
    private bool _isViewVisible;


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
        //logique de connexion ICI
        MessageBox.Show("login !", "Alerte", MessageBoxButton.OK, MessageBoxImage.Warning);
        IsViewVisible = false;
    }
    
}