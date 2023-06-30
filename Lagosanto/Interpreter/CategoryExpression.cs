namespace Lagosanto.Interpreter;

public class CategoryExpression: TerminalExpression
{
    
    public string _value;
    
    public CategoryExpression(string value) {
        _value = value;
    }
    
    
    public override void Interpreter(Context context)
    {
        context.NewArticle._details.category = _value;
    }
}