using System.Diagnostics;

namespace Lagosanto.Services;

abstract class ProductionService
{
    public static void LaunchProduction(int RecipeId, int Quantity)
    {
        Process process = new Process();
        process.StartInfo.FileName = "<application or file>";
        process.StartInfo.Arguments = "production "+RecipeId+" "+Quantity;
        process.Start();
    }
}