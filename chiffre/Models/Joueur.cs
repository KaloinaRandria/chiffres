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

    public Joueur[] GenererJoueur()
    {
        List<Joueur> toReturn = new List<Joueur>();
        for (int i = 0; i < 2; i++)
        {
            int id = i + 1;
            toReturn.Add(new Joueur(id , "Joueur " + id , -1));
        }
        return toReturn.ToArray();
    }

    public int GetJoueurById(int id , Joueur[] joueurs)
    {
        for (int i = 0; i < joueurs.Length; i++)
        {
            if (joueurs[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }

    public bool CheckJoueurSiMiser(Joueur[] joueurs)
    {
        for (int i = 0; i < joueurs.Length; i++)
        {
            if (joueurs[i].Nombre == -1)
            {
                return true;
            }
        }

        return false;
    }

    public int JoueurTour(Joueur[] joueurs)
    {
        if (new Joueur().CheckJoueurSiMiser(joueurs))
        {
            return -1;
        }

        return joueurs[0].Id;
    }

    public int GetAutreIdJoueur(int id , Joueur[] joueurs)
    {
        for (int i = 0; i < joueurs.Length; i++)
        {
            if (joueurs[i].Id != id)
            {
                return joueurs[i].Id;
            }
        }

        return id;
    }

    public Joueur[] JoueurValiderChoix(string validation , string nombre)
    {
        Joueur joueur = new Joueur();
        String[] valeurs = validation.Split("&");
        Joueur[] joueurs = joueur.GenererJoueur();
        for (int i = 0; i < valeurs.Length; i++)
        {
            int idJoueur = Convert.ToInt32(valeurs[i].Split("_")[0]);
            int tempNumber = Convert.ToInt32(valeurs[i].Split("_")[1]);
            joueurs[joueur.GetJoueurById(idJoueur, joueurs.ToArray())].Nombre = tempNumber;
        }

        joueurs = joueur.NombrePrediParJoueur(Convert.ToInt32(nombre), joueurs);
        return joueurs;
    }

    public int GetGagnant(string validation ,string nombre , string combinaison , string sevenNumberJson)
    {
        Joueur joueur = new Joueur();
        Joueur[] joueurs = joueur.JoueurValiderChoix(validation, nombre);
        int gagnant = joueur.GetAutreIdJoueur(joueur.JoueurTour(joueurs), joueurs);
        List<int> sevenRandom = new Chiffre().ExtractionNombre(sevenNumberJson);
        List<int> combinaisons = new Chiffre().ExtractionNombre(combinaison);
        if (new Chiffre().CheckCombinaison(combinaisons,sevenRandom) == false)
        {
            return gagnant;
        }

        int valueCombinaison = new Chiffre().EvaluateExpression(combinaison);
        if (valueCombinaison == joueurs[0].Nombre)
        {
            gagnant = joueur.JoueurTour(joueurs);
        }
        return gagnant;
    }
    
}