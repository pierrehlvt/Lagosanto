using System;
using System.Collections.Generic;
using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Models;

namespace Lagosanto.Interpreter.Parser.ChainOfResponsability;

public class NewArticleTokenHandler : TokenHandler
{
    public override IExpression Execute(IExpression expression, ParserTreeText treeText)
    {
        if (treeText.Token.Equals("", StringComparison.InvariantCultureIgnoreCase))
        {
            if (treeText.CountChildren == 4)
            {

                NewArticle newArticle = new()
                {
                    codeArticle = treeText.GetChild(0).Element,
                    category = treeText.GetChild(1).Element,
                    codeOperation = treeText.GetChild(2).Element,
                    components = new List<Component>()
                };
                
                int test = 0;
                return new NewArticleExpression(newArticle);
            }
        }

        return this.Next.Execute(expression, treeText);

    }
}