using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class TernaryExpression : NaryExpression {
    protected TernaryExpression(IExpression left,IExpression middle, IExpression right) : base() {
        this.Expressions.Add(left);
        this.Expressions.Add(middle);
        this.Expressions.Add(right);
    }

    public IExpression Left {
        get => this.Expressions[0]; set { this.Expressions[0] = value; }
    }
    public IExpression Middle {
        get => this.Expressions[1]; set { this.Expressions[1] = value; }
    }
    public IExpression Right {
        get => this.Expressions[2]; set { this.Expressions[2] = value; }
    }
        


}