using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Models;

namespace Lagosanto.Interpreter;

public class NewArticleExpression : TerminalExpression {
    
    public NewArticle NewArticle { get; set; }
    
    public NewArticleExpression(NewArticle newArticle) {
        this.NewArticle = newArticle;
    }
    public override void Interpreter(Context context)
    {
        context.NewArticle = this.NewArticle.Clone() as NewArticle;
    }
}