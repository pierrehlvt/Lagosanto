using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class BinaryExpression : NaryExpression {
    protected BinaryExpression(IExpression left, IExpression right) : base() {
        this.Expressions.Add(left);
        this.Expressions.Add(right);
    }

    public IExpression Left {
        get => this.Expressions[0]; set { this.Expressions[0] = value; }
    }

    public IExpression Right {
        get => this.Expressions[1]; set { this.Expressions[1] = value; }
    }
        


}
