
using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class UnaryExpression: Expression
{
        protected UnaryExpression(IExpression expression) : base() {
            Expression = expression;
        }

        public IExpression Expression { get; set; }
        
}