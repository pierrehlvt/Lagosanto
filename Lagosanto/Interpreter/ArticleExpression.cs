using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class ArticleExpression : BinaryExpression {
    public ArticleExpression(IExpression left,IExpression right ) : base(left,right) {
            
    }

    public override void Interpreter(Context context) {
        Context leftContext = new Context();
        Context rightContext = new Context();
        
        Left.Interpreter(leftContext);
        Right.Interpreter(rightContext);

    }
}