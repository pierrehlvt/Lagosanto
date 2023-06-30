using System;
using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter.Parser.ChainOfResponsability;

public class ComponentTokenHandler : TokenHandler {
    public override IExpression Execute(IExpression expression, ParserTreeText treeText) {
        if (treeText.Token.Equals("CPS", StringComparison.InvariantCultureIgnoreCase)) {
            if (treeText.CountChildren == 6) {
                return new ComponentExpression(TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(0))), 
                    TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(1))));
            }
        }

        return this.Next.Execute(expression, treeText);
    }
}