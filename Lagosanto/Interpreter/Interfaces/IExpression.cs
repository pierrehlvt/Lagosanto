using Lagosanto.Models;

namespace Lagosanto.Interpreter.Interfaces;

public interface IExpression
{
    void Interpret(Context context);
}