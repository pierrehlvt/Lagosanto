using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Interpreter.Parser;

namespace Lagosanto.Interpreter.ChainOfResponsability;

abstract public class TokenHandler
{
    public TokenHandler Next { get; set; }

    public abstract IExpression Execute(IExpression expression, ParserTreeText treeText);
}