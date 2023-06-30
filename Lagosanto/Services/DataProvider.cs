using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Lagosanto.Models;
using Newtonsoft.Json;

namespace Lagosanto.Services;

public class DataProvider
{
    private readonly HttpClient _client = new();

    public DataProvider()
    {
        _client.BaseAddress = new Uri("http://82.64.231.72:8000/");
    }

    public List<Category> GetAllCategories()
    {
        var response = _client.GetAsync("categories").Result;

        if (response.IsSuccessStatusCode)
        {
            var jsonString = response.Content.ReadAsStringAsync().Result;
            var categories = JsonConvert.DeserializeObject<List<Category>>(jsonString);

            List<Category> data = new();

            foreach (var category in categories)
            {
                data.Add(new Category
                {
                    Id = category.Id,
                    Code = category.Code,
                    Libelle = category.Libelle
                });
            }

            return data;
        }

        Console.WriteLine("La requête a échoué avec le code : " + response.StatusCode);
        return null;
    }

    public async Task<List<Article>> GetAllArticles()
    {
        HttpResponseMessage response = await _client.GetAsync("articles");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var articles = JsonConvert.DeserializeObject<List<Article>>(jsonString);

            foreach (var article in articles)
            {
                var data = new Article()
                {
                    Id = article.Id,
                    Code = article.Code,
                    Libelle = article.Libelle,
                    CategoryId = article.CategoryId
                };

                return new List<Article> {data};
            }
        }

        Console.WriteLine("La requête a échoué avec le code : " + response.StatusCode);
        return null;
    }

    public List<Operation> GetAllOperations()
    {
        HttpResponseMessage response = _client.GetAsync("operations").Result;

        if (response.IsSuccessStatusCode)
        {
            var jsonString = response.Content.ReadAsStringAsync().Result;
            var operations = JsonConvert.DeserializeObject<List<Operation>>(jsonString);

            List<Operation> data = new();

            foreach (var operation in operations)
            {
                data.Add(new Operation
                {
                    Id = operation.Id,
                    Code = operation.Code,
                    Libelle = operation.Libelle,
                    Delai = operation.Delai,
                    DelaiInstallation = operation.DelaiInstallation
                });
            }

            return data;
        }

        Console.WriteLine("La requête a échoué avec le code : " + response.StatusCode);
        return null;
    }
}