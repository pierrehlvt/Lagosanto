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
        
        context.NewArticle.codeArticle = leftContext.NewArticle.codeArticle;
        context.NewArticle.category = middleContext.NewArticle.category;
        context.NewArticle.codeOperation = rightContext.NewArticle.codeOperation;

    }
}