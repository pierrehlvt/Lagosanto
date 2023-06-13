using System;
using System.Collections.Generic;
using System.Linq;
using Algo.model;
using Newtonsoft.Json.Linq;

namespace Lagosanto.Services;

public class AlgorithmService
{
    
    private RecipeService _recipeService;
    private CategoryService _categoryService;
    private List<(Recipe,List<Article>)>? _finalRecipe;
    private int _count;
    private JArray _recipe = null!;
    private List<int?> _listComposant2= new List<int?>();
    private ArticleService _articleService;
    private OperationService _operationService;
    private List<Article> _listArticle = new List<Article>();
    private Operation _currentOperation = null!;
    private Category _currentCategory = null!;
    private List<Article> _listSortArticle = new List<Article>();

    public List<Article> ListSortArticle
    {
        get => _listSortArticle;
        private set => _listSortArticle = value;
    }
    
    public List<Article> ListArticle
    {
        get => _listArticle;
        private set => _listArticle = value;
    }

    public List<int?> ListComposant2
    {
        get => _listComposant2;
        set => _listComposant2 = value;
    }

    public int Counter
    {
        get => _count;
        private set => _count = value;
    }

    public JArray Recipe
    {
        get => _recipe;
        private set => _recipe = value;
    }
    
    public List<(Recipe,List<Article>)>? FinalRecipe
    {
        get => _finalRecipe;
        private set => _finalRecipe = value;
    }

    public AlgorithmService(RecipeService recipeService, ArticleService articleService, 
        OperationService operationService,CategoryService categoryService)
    {
        _recipeService = recipeService;
        _articleService = articleService;
        _categoryService = categoryService;
        _operationService = operationService;
        FinalRecipe = new List<(Recipe,List<Article>)>();
    }

    public void TestAlgo(int id)
    {
        Recipe = _recipeService.RecipeId(id);// choix de la recette de départ
        //resultat = _recipeService.RecipeId("1") = 370 tours;
        //resultat = _recipeService.RecipeId("2") = 65 tours;
        //resultat = _recipeService.RecipeId("3") = 4984 tours;
        //resultat = _recipeService.RecipeId("4") = 7 tours;
        //resultat = _recipeService.RecipeId("5") = 3038 tours;
        //resultat = _recipeService.RecipeId("6") = 10 tours;
        //resultat = _recipeService.RecipeId("7") = 4926 tours;
        //resultat = _recipeService.RecipeId("8") = 372 tours;
        
        while (Recipe.Count > 0)
        {
            Counter++;
            
            Console.WriteLine("Itération : " +Counter);

            foreach (var jToken in Recipe)
            {
                var item = (JObject)jToken;
                // Access the properties of each item
                int? idArticle =(int?) item["id_article"];
                int? idOperation = (int?)item["id_operation"];
                int? idComponent1 = (int?)item["id_composant1"];
                int quantity1 = (int)item["quantite1"];
                int? idComponent2 = (int?)item["id_composant2"];
                ListArticle = new List<Article>();
                int quantity2 = 0;
                
                if (idComponent2 != null)
                {
                    quantity2 = (int)item["quantite2"];
                    _listComposant2.Add(idComponent2);
                    AddArticle(idComponent2,idOperation,quantity2);
                }

                if (idComponent1 != null)
                {
                    Recipe = _recipeService.RecipeId(idComponent1);//on remplace la recette par la recette du composant1
                    Recipe newRecipe = new Recipe(idOperation, idArticle, idComponent1, quantity1,
                        idComponent2, quantity2);
                    
                    AddArticle(idComponent1,idOperation,quantity1);

                    FinalRecipe?.Add((newRecipe, ListArticle));

                        if (Recipe.Count == 0 && _listComposant2.Count > 0)
                    {
                        int next = 1;
                        bool foundRecipe = false;

                        while (next <= _listComposant2.Count)
                        {
                            Recipe = _recipeService.RecipeId(_listComposant2[next - 1]);//on remplace la recette par la recette du composant2

                            if (Recipe.Count == 0)
                            {
                                next++;
                            }
                            else
                            {
                                _listComposant2.RemoveRange(0, next);
                                foundRecipe = true;
                                break;
                            }
                        }

                        if (!foundRecipe)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }

    public void CountArticle()
    {

        if (FinalRecipe != null && FinalRecipe.Count > 0)
        {
            Console.WriteLine("Liste des articles et de leur quantité :");
            Console.WriteLine("Pour la recette : " + FinalRecipe[0].Item1.IdArticle);
            Console.WriteLine("----------------------------------------------------");
            Dictionary<int, int> articleCounts = new Dictionary<int, int>();
            Dictionary<int, Article> articleObjects = new Dictionary<int, Article>();

            foreach ((Recipe recipe, List<Article> articles) in FinalRecipe)
            {

                if (recipe.IdComponent1 !=null)
                {
                    if (articleCounts.ContainsKey((int)recipe.IdComponent1))
                    {
                        articleCounts[(int)recipe.IdComponent1]++;
                    }else
                    {
                        articleCounts[(int)recipe.IdComponent1] = 1;
                        articleObjects[(int)recipe.IdComponent1] = articles[0]; // Assuming each article ID maps to a single Article object
                    }
                }


                if (recipe.IdComponent2 != null)
                {
                    if (articleCounts.ContainsKey((int)recipe.IdComponent2))
                    {
                        articleCounts[(int)recipe.IdComponent2]++;
                    }else
                    {
                        articleCounts[(int)recipe.IdComponent2] = 1;
                        articleObjects[(int)recipe.IdComponent2] = articles[1]; // Assuming each article ID maps to a single Article object
                    }
                }
            }

            var sortedCounts = articleCounts.OrderByDescending(pair => pair.Value);
            int total = 0;

            foreach (KeyValuePair<int, int> articleCount in sortedCounts)
            {
                total += articleCount.Value;
                int articleId = articleCount.Key;
                Article article = articleObjects[articleId];
                int count = (articleCount.Value * article.Quantity);

                string resume="Il faut "+count+" fois l'article "+articleId+" [Article: ID=" + articleId+ ", Code=" + article.Code + ", Label=" +
                              article.Label.Replace("\n", "") + ", Category ID=" + article.IdCategory + ", " +
                              " Categorie[id="+article.Category.Id+" , label="+article.Category.Label+", code="+article.Category.Code+"], "+
                              "Operation[id=" + article.Operation.Id + ", " +
                              "label=" + article.Operation.Label + ", delai=" + article.Operation.Delay +
                              ", code=" + article.Operation.Code + ", installationDelay=" +article.Operation.InstallationDelay
                              + "]]";
                
                Console.WriteLine(resume);
            }
        }
    }

    private void AddArticle(int? idArticle, int? idOperation,int quantity)
    {      
        JArray article = _articleService.ArticleId(idArticle);
        JArray operation = _operationService.OperationId(idOperation);
        
        if (article.Count > 0)
        {
            foreach (var value in article)
            {
                int id = (int) value["id"]!;
                string code = (string) value["code"]!;
                string label = (string) value["libelle"]!;
                int idCategory = (int) value["id_categorie"]!;
                JArray category = _categoryService.CategoryId(idCategory);

                foreach (var item in category)
                {
                    string codeCategory = (string) item["code"]!;
                    string labelCategory = (string) item["libelle"]!;
                    _currentCategory = new Category(idCategory, codeCategory, labelCategory);
                }
                
                foreach (var item in operation)
                {
                    string codeOperation = (string) item["code"]!;
                    string labelOperation = (string) item["libelle"]!;
                    int delay = (int) item["delai"]!;
                    int installationDelay = (int) item["delaiInstallation"]!;
                    _currentOperation = new Operation(idOperation, codeOperation, labelOperation, delay, 
                        installationDelay);
                }
                
                Article newArticle = new Article(id, code, label, idCategory,_currentOperation,_currentCategory,quantity);
                ListArticle.Add(newArticle);
            }
        }
    }
    
    
    
    
}