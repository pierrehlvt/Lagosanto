namespace Lagosanto.Interpreter;

public class CodeArticleExpression: TerminalExpression
{
    
    public string _value;
    
    public CodeArticleExpression(string value) {
        _value = value;
    }
    
    
    public override void Interpreter(Context context)
    {
        context.NewArticle._details.codeArticle = _value;
    }
}