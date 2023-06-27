namespace Lagosanto.Interpreter;

public class InterpreterClient
{
    public Context Context { get;private set; }

    public void ProcessInput(string userInput)
    {
        Context = new Context();

        string[] recipeInputs = userInput.Split('&');
        
        ArticleExpression articleExpression; 
        
        foreach (string recipe in recipeInputs)
        {

        }
        
    }
    
}