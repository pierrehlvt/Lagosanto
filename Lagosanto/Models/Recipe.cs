namespace Algo.model;

public class Recipe
{    
    public int? IdArticle { get; set; }
    public int? IdOperation { get; set; }
    public int? IdComponent1 { get; set; }
    public int Quantity1 { get; set; }
    public int? IdComponent2 { get; set; }
    public int Quantity2 { get; set; }
    
    public Recipe(int? idOperation, int? idArticle, int? idComponent1, int quantity1, int? idComponent2, int quantity2)
    {
        IdOperation = idOperation;
        IdArticle = idArticle;
        IdComponent1 = idComponent1;
        Quantity1 = quantity1;
        IdComponent2 = idComponent2;
        Quantity2 = quantity2;
    }
    
}