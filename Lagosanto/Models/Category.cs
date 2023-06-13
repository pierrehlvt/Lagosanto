namespace Algo.model;

public class Category
{
    private string? _code;
    public int Id { get; set; }

    public string? Code
    {
        get => _code;
        set => _code = value;
    }

    public string? Label { get; set; }

    public Category(int id, string? code, string? label)
    {
        Id = id;
        Code = code;
        Label = label;
    }
    
}