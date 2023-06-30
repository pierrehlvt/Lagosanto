using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Interpreter.Parser;
using Lagosanto.Interpreter.Parser.ChainOfResponsability;


namespace DP_NFS.parser.ChainOfResponsability {
    class ErrorTokenHandler : TokenHandler {
        public override IExpression Execute(IExpression expression, ParserTreeText treeText) {
            return new ErrorExpression();
        }
    }
}
