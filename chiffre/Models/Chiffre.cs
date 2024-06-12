using System.Data;

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

    public static int EvaluateExpression(string expression)
    {
        DataTable dataTable = new DataTable();
        var value = dataTable.Compute(expression, string.Empty);
        return Convert.ToInt32(value);
    }
}