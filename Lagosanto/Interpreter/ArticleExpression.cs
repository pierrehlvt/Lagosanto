using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class ArticleExpression : BinaryExpression 
{
    public ArticleExpression(IExpression left, IExpression right) : base(left, right) {
    }

    public void Interpreter(Context context) {
        Context leftContext = new Context();
        Context rightContext = new Context();

        Left.Interpret(leftContext);
        Right.Interpret(rightContext);

    }
}