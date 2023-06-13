namespace Algo.model;

public class Article
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Label { get; set; }
    public int? IdCategory { get; set; }
    
    public Operation Operation { get; set; }
    public Category Category { get; set; }
    
    public int Quantity { get; set; }

    public Article(int id, string? code, string? label, int? idCategory, Operation operation, Category category, int quantity)
    {
        Id = id;
        Code = code;
        Label = label;
        IdCategory = idCategory;   
        Operation = operation;
        Category = category;
        Quantity = quantity;
    }
}