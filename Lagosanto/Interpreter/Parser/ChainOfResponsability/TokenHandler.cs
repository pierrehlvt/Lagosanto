using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter.Parser.ChainOfResponsability;

public abstract class TokenHandler {
        public TokenHandler Next { get; set; }
        public abstract IExpression Execute(IExpression expression, ParserTreeText treeText);
}