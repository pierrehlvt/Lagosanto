using System;

namespace Lagosanto.Models;

public class Details: ICloneable
{
    
    public Details() : this("", "", "") { }

    public Details(string codeArticle, string category, string operation)
    {
        this.codeArticle = codeArticle;
        this.category = category;
        this.operation = operation;
        
    }

    public string codeArticle { get; set; }
    public string category { get; set; }
    public string operation { get; set; }
    public Details Data { get; set; }

    public object Clone()
    {
        
        return new Details(codeArticle, category, operation);
    }
}