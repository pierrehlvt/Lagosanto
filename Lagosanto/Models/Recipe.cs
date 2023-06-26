using System.Collections.Generic;
using Lagosanto.Models.Interfaces;

namespace Lagosanto.Models;

public class Recipe : IRecipe
{
    public int ArticleId { get; set; }
    public int OperationId { get; set; }
    public List<IRecipe> Components => new();
    public decimal Quantity { get; set; }
}