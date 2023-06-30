using System;
using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter.Parser.ChainOfResponsability;

public class DetailsTokenHandler : TokenHandler
{
    public override IExpression Execute(IExpression expression, ParserTreeText treeText) {
        if (treeText.Token.Equals("DTS", StringComparison.InvariantCultureIgnoreCase))
        {
            if (treeText.CountChildren == 1)
            { 
                return new DetailsExpression(TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(0))),
                    TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(1)))
                    , TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(2))));
            }
        }
        return this.Next.Execute(expression, treeText);
    }
}