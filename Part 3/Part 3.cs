using System.Globalization;

public class Part2
{
    public static void Main(string[] args)
    {
        const int currentyear = 2023;
        const int markyear = 2000;
        Console.WriteLine ("Enter your year of birth: ");
        int year = Convert.ToInt32(Console.ReadLine());
        // int century = (year / 100) + 1;
        if (year > markyear && year < currentyear)
        {
            Console.WriteLine("You are born in the 21st century.");
        } else if (year < markyear && year > 1901)
        {
            Console.WriteLine("You are born in the 20th century.");
        } else if (year > currentyear)
        {
            Console.WriteLine("Error - this year is in the future.");
        } else
        {
            Console.WriteLine("Impossible");
        }
    }
}
