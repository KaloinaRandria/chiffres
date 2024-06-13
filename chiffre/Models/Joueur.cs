namespace chiffre.Models;

public class Joueur
{
    private int Id { get; set; }
    private string Nom { get; set; }
    private int Nombre { get; set; }

    public Joueur(int id, int nombre)
    {
        Id = id;
        Nombre = nombre;
    }
    public Joueur(){}

    public Joueur[] NombrePrediParJoueur(int nombre , Joueur[] joueurs)
    {
        Array.Sort(joueurs , (joueur1, joueur2) =>
        {
            int diff1 = Math.Abs(joueur1.Nombre - nombre);
            int diff2 = Math.Abs(joueur2.Nombre - nombre);
            return diff1.CompareTo(diff2);
        });
        return joueurs;
    }

    public Joueur(int id, string nom, int nombre)
    {
        Id = id;
        this.Nom = nom;
        Nombre = nombre;
    }

    public static List<Joueur> GenererJoueur(int nbJoueurs)
    {
        List<Joueur> toReturn = new List<Joueur>();
        for (int i = 0; i < nbJoueurs; i++)
        {
            int id = i + 1;
            toReturn.Add(new Joueur(id , "Joueur " + id , -1));
        }
        return toReturn;
    }

    public bool CommonNumber(Joueur[] joueurs)
    {
        HashSet<int> numbers = new HashSet<int>();
        for (int i = 0; i < joueurs.Length; i++)
        {
            if (numbers.Contains(joueurs[i].Nombre))
            {
                return true;
            }
            numbers.Add(joueurs[i].Nombre);
        }
        return false;
    }
}