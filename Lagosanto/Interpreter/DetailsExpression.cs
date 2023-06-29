using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class DetailsExpression : TernaryExpression {
    public DetailsExpression(IExpression left,IExpression middle,IExpression right ) : base(left,middle,right) {
            
    }

    public override void Interpreter(Context context) {
        Context leftContext = new Context();
        Context middleContext = new Context();
        Context rightContext = new Context();
        
        Left.Interpreter(leftContext);
        Middle.Interpreter(middleContext);
        Right.Interpreter(rightContext);
        
        context.NewArticle._details.codeArticle = leftContext.NewArticle._details.codeArticle;
        context.NewArticle._details.category = middleContext.NewArticle._details.category;
        context.NewArticle._details.operation = rightContext.NewArticle._details.operation;

    }
}