using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace Lagosanto.CustomControls;

public partial class BindablePassword : UserControl
{

    public static DependencyProperty passwordProperty=DependencyProperty.Register("Password",typeof(SecureString),typeof(BindablePassword));


    public SecureString Password
    {
        get
        {
            return (SecureString)GetValue(passwordProperty);
        }
        set
        {
            SetValue(passwordProperty,value);
        }
    }
    public BindablePassword()
    {
        InitializeComponent();
        InputPassword.PasswordChanged += OnPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        Password = InputPassword.SecurePassword;
    }
}