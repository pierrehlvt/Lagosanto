﻿namespace Lagosanto.Models;

public class Article
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Libelle { get; set; }
    public Category CategoryId { get; set; }
}