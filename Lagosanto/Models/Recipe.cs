namespace Lagosanto.Models;

public class Recipe
{
    public int ArticleId { get; set; }
    public int OperationId { get; set; }
    public int IdComposant1 { get; set; }
    public int Quantity1 { get; set; }
    public int IdComposant2 { get; set; }
    public int Quantity2 { get; set; }
}