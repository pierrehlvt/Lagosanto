using System;
using System.Collections.Generic;

namespace Lagosanto.Models;

public class NewArticle:ICloneable
{
    public NewArticle Data { get; set; } = new NewArticle("","","",new List<Component>());

    public string codeArticle { get; set; }
    public string category { get; set; }
    public string codeOperation { get; set; }
    public List<Component> components { get; set; }
    
    public void setCodeArticle(string codeArticle)
    {
        Data.codeArticle = codeArticle;
    }
    
    public void setCategory(string category)
    {
        Data.category = category;
    }
    
    public void setCodeOperation(string codeOperation)
    {
        Data.codeOperation = codeOperation;
    }
    
    public void setComponents(List<Component> components)
    {
        Data.components = components;
    }
    public NewArticle() : this("","","",new List<Component>()) { }
    public NewArticle(string codeArticle, string category, string codeOperation, List<Component> components)
    {
        this.codeArticle = codeArticle;
        this.category = category;
        this.codeOperation = codeOperation;
        this.components = components;
    }
    public object Clone()
    {
        return new NewArticle(Data.codeArticle, Data.category, Data.codeOperation, Data.components);
    }
}