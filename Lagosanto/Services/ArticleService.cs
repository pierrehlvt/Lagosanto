using System;
using System.Net.Http;
using System.Threading.Tasks;
using Lagosanto.Services;
using Lagosanto.Services.interfaces;
using Newtonsoft.Json.Linq;
namespace Lagosanto.Services;

public class ArticleService : IHttp
{
    
    private string? Article { get; set; }
    private HttpClient _httpClientService=new HttpClient();
    

    public JArray ArticleId(int? id)
    {
        GetOneAsync("article",id).Wait();
        JArray recipe = StringToArrayConverterService.Convert(Article);
        return recipe;
    }
    

    public async Task<string> GetOneAsync(string route, int? id)
    {
        try
        {
            // Send a GET request to the URL and retrieve the response
            HttpResponseMessage response = await _httpClientService.GetAsync("http://82.64.231.72:8000/"+route+"/" + id);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the content of the response as a string
                string content = await response.Content.ReadAsStringAsync();
                // Display the retrieved data
                Article = content;
                return Article;
            }
        }catch (Exception ex) {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        
        return "";
    }
}