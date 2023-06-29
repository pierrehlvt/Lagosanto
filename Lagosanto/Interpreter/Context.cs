using System.Collections.Generic;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class Context
{
    public NewArticle NewArticle { get; set; }
    public Details Details { get; set; }
    
    public Component Component { get; set; }
    
    public bool IsWrong { get; set; }
    
    
    public Context()
    {
        NewArticle = new NewArticle(Details, Component);
    }
    
    public override string ToString()
    {
        if (this.IsWrong) {
            return "ERROR";
        }
        return NewArticle.ToString();
    }

}