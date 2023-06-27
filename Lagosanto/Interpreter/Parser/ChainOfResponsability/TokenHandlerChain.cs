using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Interpreter.Parser;

namespace Lagosanto.Interpreter.ChainOfResponsability;

public class TokenHandlerChain: TokenHandler
{
    private static TokenHandlerChain _instance = null;
    public static TokenHandlerChain Instance {
        get {
            if (TokenHandlerChain._instance == null) {
                TokenHandlerChain._instance = new TokenHandlerChain();
            }
            return TokenHandlerChain._instance;
        }
    }

    private TokenHandlerChain() : base() {
        TokenHandler last = this;
      //  last = TokenHandlerChain.AddNext(last, new AndTokenHandler());
    }

    private static TokenHandler AddNext(TokenHandler current, TokenHandler next) {
        current.Next = next;
        return next;
    }

    public override IExpression Execute(IExpression expression, ParserTreeText treeText) {
        return Next.Execute(expression, treeText);
    }
}