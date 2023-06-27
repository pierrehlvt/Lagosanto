using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class Expression :IExpression
{
    public abstract void Interpret(Context context);
}