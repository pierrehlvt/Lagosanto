using System.Collections.Generic;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class Context
{
    public NewArticle NewArticle { get; set; }
    
    public Context()
    {
        NewArticle = new NewArticle();
    }
    
    public override string ToString()
    {
        return NewArticle.ToString();
    }

}