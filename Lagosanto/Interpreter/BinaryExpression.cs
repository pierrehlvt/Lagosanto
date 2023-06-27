using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class BinaryExpression: NaryExpression
{
    protected BinaryExpression(IExpression left, IExpression right){
        Expressions.Add(left);
        Expressions.Add(right);
    }

    public IExpression Left {
        get => Expressions[0]; set { Expressions[0] = value; }
    }

    public IExpression Right {
        get => Expressions[1]; set { Expressions[1] = value; }
    }
}