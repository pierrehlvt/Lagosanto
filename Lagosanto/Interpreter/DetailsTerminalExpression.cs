using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class DetailsTerminalExpression: TerminalExpression
{
    public Details _Details { get; set; }
    public DetailsTerminalExpression(CodeArticleExpression value,OperationExpression value1,CategoryExpression value2)
    {
        _Details= new Details(value._value,value1._value,value2._value);
    }
    
    public override void Interpreter(Context context)
    {
        context.Details= (Details) _Details.Clone();
    }
}