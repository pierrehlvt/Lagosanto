using System;
using System.Collections.Generic;

namespace Lagosanto.Models;

public class NewArticle:ICloneable
{
    public NewArticle Data { get; set; } = new NewArticle(new Details(),new Component());

    public Details _details;
    public Component _components;
    
    public NewArticle() : this(new Details(),new Component()) { }
    public NewArticle(Details detail, Component component)
    {
        this._details = detail;
        this._components = component;
    }
    public object Clone()
    {
        return new NewArticle(Data._details, Data._components);
    }
}