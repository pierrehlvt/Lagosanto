using Lagosanto.Models;

class Interpreter
{
    private Expression expression;

    public Interpreter(Expression expression)
    {
        this.expression = expression;
    }

    public string Interpret(Context context)
    {
        return expression.Interpreter(context);
    }
}