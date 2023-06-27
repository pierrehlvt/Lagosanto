using System.Collections.Generic;

namespace Lagosanto.Models;

class Context
{
    private Dictionary<int, string> composants;

    public Context()
    {
        composants = new Dictionary<int, string>
        {
            { 34, "Composant A" },
            // Ajouter d'autres composants si nécessaire
        };
    }

    public string GetComposant(int idComposant)
    {
        if (composants.ContainsKey(idComposant))
        {
            return composants[idComposant];
        }
        return null;
    }
}