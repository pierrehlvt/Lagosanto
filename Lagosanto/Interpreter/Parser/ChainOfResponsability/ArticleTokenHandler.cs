using System;
using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Interpreter.TreeNode;

namespace Lagosanto.Interpreter.Parser.ChainOfResponsability;

public class ArticleTokenHandler : TokenHandler {
    public override IExpression Execute(IExpression expression, ParserTreeText treeText) {
        if (treeText.Token.Equals("ART", StringComparison.InvariantCultureIgnoreCase))
        {
            if (treeText.CountChildren == 2)
            {
                
                return new ArticleExpression(TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(0))),
                    TokenHandlerChain.Instance.Execute(expression, new ParserTreeText(treeText.GetChild(1))));
            }
        }
        return this.Next.Execute(expression, treeText);
    }
}