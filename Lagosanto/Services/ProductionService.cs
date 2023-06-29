using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Documents;

namespace Lagosanto.Services;

public class ProductionService
{
    public List<String> LaunchProduction(int RecipeId, int Quantity)
    {
        return RunJarFile(RecipeId, Quantity);
    }
    
    public List<String> RunJarFile(int RecipeId, int Quantity)
    {
        string jarPath = Path.Combine(Directory.GetCurrentDirectory(), "NFS_4BCI_ALGORYTHME-1.0-SNAPSHOT.jar");
        List<String> arguments = new List<String>();
        
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "java",
            Arguments = $"-jar \"{jarPath}\" {RecipeId} {Quantity}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false, 
            CreateNoWindow = true,
        };
        
        using (Process process = Process.Start(startInfo))
        {
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                arguments.Add(line);
            }

            // read standard error
            while (!process.StandardError.EndOfStream) // add this block
            {
                string line = process.StandardError.ReadLine();
                Debug.WriteLine("Error : " + line);
            }
            
            process.WaitForExit();
        }
        
        arguments.RemoveRange(0,3);

        return arguments;
    }

}