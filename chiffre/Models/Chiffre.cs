using System.Data;
using System.Text.RegularExpressions;

namespace chiffre.Models;

public class Chiffre
{
    public int RandomNumber(int number)
    {
        return new Random().Next(1, number);
    }

    public int[] RandomSevenNumber(int number , int length)
    {
        int[] valiny = new int[length];
        for (int i = 1; i <= length; i++)
        {
            valiny[i-1] = RandomNumber(number);
        }
        return valiny;
    }

    public int EvaluateExpression(string expression)
    {
        DataTable dataTable = new DataTable();
        var value = dataTable.Compute(expression, string.Empty);
        return Convert.ToInt32(value);
    }

    public List<int> ExtractionNombre(string reponseJoueur)
    {
        string pattern = @"[-+]?\d*\.\d+|\d+";
        List<string> nombres = new List<string>();
        MatchCollection matchCollection = Regex.Matches(reponseJoueur, pattern);
        foreach (Match match in matchCollection)
        {
            nombres.Add(match.Value);
        }

        List<int> toReturn = new List<int>();
        for (int i = 0; i < toReturn.Count; i++)
        {
            toReturn.Add(Convert.ToInt32(nombres[i]));
        }

        toReturn = toReturn.OrderByDescending(x => x).ToList();
        return toReturn;
    }

    public bool CheckCombinaison(List<int> combinaisons , List<int> sevenRandom)
    {
        Dictionary<int, int> dictionary = combinaisons.GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
        foreach (var kvp in dictionary)
        {
            int number = kvp.Key;
            int occurences = kvp.Value;
            
            int countInSevenList = sevenRandom.Count(x => x == number);
            
            if (occurences > countInSevenList)
            {
                return false;
            }
        }
        return true;
    }
}