using System.Collections.Generic;
using Lagosanto.Interpreter.Interfaces;

namespace Lagosanto.Interpreter;

public abstract class NaryExpression : Expression {
    protected NaryExpression() : base() {
        this.Expressions = new List<IExpression>();
    }

    protected List<IExpression> Expressions { get; set; }
}