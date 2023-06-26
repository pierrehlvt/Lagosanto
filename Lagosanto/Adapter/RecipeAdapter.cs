using System.Collections.Generic;
using Lagosanto.Models.Interfaces;

namespace Lagosanto.Adapter;

public class RecipeAdapter : IRecipe
{
    private readonly int _articleId;
    private readonly int _operationId;
    private int _componentId;
    private readonly decimal _quantity;

    public RecipeAdapter(int articleId, int operationId, int componentId, decimal quantity)
    {
        _articleId = articleId;
        _operationId = operationId;
        _componentId = componentId;
        _quantity = quantity;
    }
    
    public int ArticleId { get; }
    public int OperationId { get; }
    public List<IRecipe> Components { get; }
    public decimal Quantity { get; }
}