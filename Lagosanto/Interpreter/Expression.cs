namespace Lagosanto.Models;

abstract class Expression
{
    public abstract string Interpreter(Context context);
}