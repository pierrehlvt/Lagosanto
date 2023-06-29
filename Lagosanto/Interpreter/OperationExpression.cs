namespace Lagosanto.Interpreter;

public class OperationExpression: TerminalExpression
{
    
    public string _value;
    
    public OperationExpression(string value) {
        _value = value;
    }
    
    
    public override void Interpreter(Context context)
    {
        context.NewArticle._details.codeArticle = _value;
    }
}