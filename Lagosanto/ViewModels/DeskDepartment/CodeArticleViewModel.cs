using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Lagosanto.ViewModels.DeskDepartment;

public class CodeArticleViewModel:ViewModelBase
{

    private string _codeArticle = "";
    
    public string CodeArticle
    {
        get { return _codeArticle; }
        set
        {
            _codeArticle = value;
            OnPropertyChanged(nameof(CodeArticle));
        }
    }
    
    public ICommand AddCodeArticleCommand { get; }

    public CodeArticleViewModel()
    {
        AddCodeArticleCommand = new ViewModelCommand(ExecuteAddCodeArticleCommand,CanExecuteAddCodeArticleCommand);
    }
    private void ExecuteAddCodeArticleCommand(object obj)
    {

        CodeArticle = "ART(DTS("+CodeArticle+",";
        Application.Current.MainWindow.Close();
    }
    
    private bool CanExecuteAddCodeArticleCommand(object obj)
    {
        if (CodeArticle.Length < 1)
        {
            return false;
        }
        
        string pattern = @"^[^\W_]{4}$";
        
        if (!Regex.IsMatch(CodeArticle, pattern))
        {
            return false;
        }
        
        return true;
    }
    
}