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
        AddCodeArticleCommand = new ViewModelCommand(ExecuteAddCodeArticleCommand);
    }
    private void ExecuteAddCodeArticleCommand(object obj)
    {
        MessageBox.Show(CodeArticle,"",MessageBoxButton.OK,MessageBoxImage.Information);
    }
    
}