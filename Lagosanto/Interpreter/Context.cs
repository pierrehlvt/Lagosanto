using System.Collections.Generic;

namespace Lagosanto.Interpreter;

public class Context
{
    public string ArticleType { get; set; }
    public string CategoryType { get; set; }
    public string OperationType { get; set; }
    public List<string> Articles { get; } = new List<string>();
    public List<(string, int)> ArticleQuantities { get; } = new List<(string, int)>();

    public void AddArticle(string codeArticle)
    {
        Articles.Add(codeArticle);
    }

    public void AddArticleQuantity(string codeArticle, int quantity)
    {
        ArticleQuantities.Add((codeArticle, quantity));
    }
}