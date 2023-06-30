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
                
                return new DetailsTerminalExpression(
                        new CodeArticleExpression(treeText.GetChild(0).Element),
                        new OperationExpression(treeText.GetChild(1).Element),
                        new CategoryExpression(treeText.GetChild(2).Element)
                );
            }

            if (treeText.CountChildren == 4)
            {
                
                
              //  return new NewArticleExpression(new Article(new Details(),new Component()));
 
            }
        }

        return this.Next.Execute(expression, treeText);

    }
}