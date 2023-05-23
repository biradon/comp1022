using System.Globalization;

public class Part2
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("What is your pH drinling water: ");
        float pHrate = float.Parse(Console.ReadLine(),CultureInfo.InvariantCulture.NumberFormat);
        if (pHrate < 7.0)
        {
            Console.WriteLine("Your water is below the acceptable rate!!!! The acceptable is in the range of 7.0 to 10.5");
        } else if (pHrate > 10.5)
        {
            Console.WriteLine("Your water is above the acceptable rate!!! The acceptable is in the range of 7.0 to 10.5");
        } else
        {
            Console.WriteLine("Your water is in acceptable rate :) The acceptable is in the range of 7.0 to 10.5 ");
        }
    }
}
