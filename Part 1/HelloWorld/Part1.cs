using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        const int MAX = 31;
        Console.WriteLine ("Input your date of birth: ");
        int date = Convert.ToInt32(Console.ReadLine());
        if (date > MAX)
        {
            Console.WriteLine("The date of birth can not be more than 31");
        }
        Console.WriteLine("Your date of birth is: " + date);
    }
}