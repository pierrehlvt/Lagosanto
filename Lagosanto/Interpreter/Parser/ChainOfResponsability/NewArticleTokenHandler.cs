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
            if (treeText.CountChildren == 3)
            {

                NewArticle newArticle = new()
                {
                    _details = new Details()
                    {
                        
                    },
                    _components = new Component()
                    {
                    }
                };
                
                return new NewArticleExpression(newArticle);
            }
        }

        return this.Next.Execute(expression, treeText);

    }
}