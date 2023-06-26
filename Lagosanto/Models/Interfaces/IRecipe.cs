using System.Collections.Generic;

namespace Lagosanto.Models.Interfaces;

public interface IRecipe
{
    int ArticleId { get; }
    int OperationId { get; }
    List<IRecipe> Components { get; }
    decimal Quantity { get; }
}