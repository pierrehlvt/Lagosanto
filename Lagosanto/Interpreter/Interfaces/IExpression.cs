using Lagosanto.Models;

namespace Lagosanto.Interpreter.Interfaces;

public interface IExpression
{
    void Interpreter(Context context);
}