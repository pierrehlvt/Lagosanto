using System;
using System.Diagnostics;

namespace Lagosanto.Services;

public class ProductionService
{
    public void LaunchProduction(int RecipeId, int Quantity)
    {
        RunJarFile(RecipeId, Quantity);
    }
    
    public void RunJarFile(int RecipeId, int Quantity)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "java",
            Arguments = "-jar NFS_4BCI_ALGORYTHME-1.0-SNAPSHOT.jar" + " " + RecipeId + " " + Quantity,
            RedirectStandardOutput = true, 
            UseShellExecute = false, 
            CreateNoWindow = false,
        };
        
        using (Process process = Process.Start(startInfo))
        {
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
            }

            process.WaitForExit();
        }
    }

}