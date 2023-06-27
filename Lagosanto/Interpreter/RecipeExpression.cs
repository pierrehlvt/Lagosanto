using Lagosanto.Models;

class RecipeExpression : Expression
{
    private int idComposant1;
    private int quantite1;
    private int? idComposant2;
    private int? quantite2;

    public RecipeExpression(int idComposant1, int quantite1, int? idComposant2, int? quantite2)
    {
        this.idComposant1 = idComposant1;
        this.quantite1 = quantite1;
        this.idComposant2 = idComposant2;
        this.quantite2 = quantite2;
    }

    public override string Interpreter(Context context)
    {
        // Obtenir les informations des composants à partir du contexte
        string composant1 = context.GetComposant(idComposant1);
        string composant2 = context.GetComposant(idComposant2);

        // Créer la recette en utilisant les informations des composants et des quantités
        string recette = $"Recette : {composant1} x {quantite1}";
        if (composant2 != null)
        {
            recette += $", {composant2} x {quantite2}";
        }
        return recette;
    }
}
