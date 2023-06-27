using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class ComponentExpression : BinaryExpression {
    public ComponentExpression(IExpression left, IExpression right) : base(left, right) {
    }

    public override void Interpreter(Context context) {
        Context leftContext = new Context();
        Context rightContext = new Context();

        Left.Interpreter(leftContext);
        Right.Interpreter(rightContext);

        var component = new Component()
        {
            codeArticle = leftContext.NewArticle.codeArticle,
            quantity = rightContext.NewArticle.components[0].quantity
        };
            
        context.NewArticle.components.Add(component);
    }
}