using System;
using Lagosanto.Interpreter;
using Lagosanto.Models;


public class ErrorExpression : TerminalExpression {
        public NewArticle _NewArticle { get; set; }

        public override void Interpreter(Context context) {
            context.NewArticle = null;
            context.IsWrong = true;
        }
}
