// Name: Chau Minh Truong
// Student ID: 101411424
// Course: COMP1022 - Object Oriented Programming


public class COMP1202_S20_Assg1_101411424
{
    public static void Main(string[] args)
    {
        // Prompt to user input name
        Console.WriteLine("Input your first name");
        string firstName = Console.ReadLine();
        Console.WriteLine("Input your last name");
        string lastName = Console.ReadLine();
        Console.WriteLine("Your name is: " + firstName + " " + lastName);


        // Variable need to use in program
        int score = 0;
        int attemp1 = 0;
        int attemp2 = 0;
        int attemp3 = 0;

        // Question 1
        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine("Question 1");
            Console.WriteLine("What is the underlying technology behind cryptocurrencies like Bitcoin?");
            Console.WriteLine("A) Artificial Intelligence");
            Console.WriteLine("B) Blockchain");
            Console.WriteLine("C) Virtual Reality");
            Console.WriteLine("D) Quantum Computing");
            Console.WriteLine("Select your answer by typing A,B,C or D");
            string answer1 = Console.ReadLine();
            
            // Check the answer
            if (answer1 == "B" || answer1 == "b")
            {
                // Function calculate the score
                attemp1 = i;
                score += CalculateScore(score,i);
                Console.WriteLine("Congratulations! You got it right!");
                break;
            // If the answer is incorrect
            } else 
            {
                Console.WriteLine("Your answer is incorrect, you only have " + (4-i) + " attemp(s)");
            }
        }
        

        //Question 2
        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine("Question 2");
            Console.WriteLine("What is the process called when new cryptocurrency coins are created and added to the circulation?");
            Console.WriteLine("A) Mining");
            Console.WriteLine("B) Minting");
            Console.WriteLine("C) Printing");
            Console.WriteLine("D) Staking");
            Console.WriteLine("Select your answer by typing A,B,C or D");
            string answer2 = Console.ReadLine();
            
            // Check the answer
            if (answer2 == "A" || answer2 == "a")
            {
                // Function calculate the score
                attemp2 = i;
                score += CalculateScore(score,i);
                Console.WriteLine("Well done! That's the correct answer!");
                break;
            // If the answer is incorrect
            } else 
            {
                Console.WriteLine("Your answer is incorrect, you only have " + (4-i) + " attemp(s)");
            }
        }

        //Question 3
        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine("Question 3");
            Console.WriteLine("Which cryptocurrency is known as the digital silver and was created as a peer-to-peer electronic cash system?");
            Console.WriteLine("A) Bitcoin");
            Console.WriteLine("B) Ehtherum");
            Console.WriteLine("C) Litecoin");
            Console.WriteLine("D) Ripple");
            Console.WriteLine("Select your answer by typing A,B,C or D");
            string answer3 = Console.ReadLine();
            
            // Check the answer
            if (answer3 == "C" || answer3 == "c")
            {
                // Function calculate the score
                attemp3 = i;
                score += CalculateScore(score,i);
                Console.WriteLine("Great job! You're absolutely correct!");
                break;
            // If the answer is incorrect
            } else 
            {
                Console.WriteLine("Your answer is incorrect, you only have " + (4-i) + " attemp(s)");
            }
        }
        
        // Calculate the percentage of answer
        double percentage = ((score / 60.0) * 100.0);

        
        // Prompt to end the program
        Console.WriteLine("User name: " + firstName + " " + lastName);
        Console.WriteLine("Total score: " + score + " scores");
        Console.WriteLine("Percentage score: " + Math.Round(percentage,2) + "%");
        Console.WriteLine("Attemp of question 1: " + attemp1);
        Console.WriteLine("Attemp of question 2: " + attemp2);
        Console.WriteLine("Attemp of question 3: " + attemp3);
        Console.WriteLine("Thank you for taking the quiz, wish you have a nice day :)");


        // Function to Calculate the score. 1st attemp equal 20, 2nd 10, 3rd 5 and 4th 0
        static int CalculateScore(int score, int attemp)
        {
            if(attemp == 1)
            {
                score = 20;
            } else if (attemp == 2)
            {
                score = 10;
            } else if (attemp == 3)
            {
                score = 5;
            } else
            {
                score = 0;
            }
            return score;
        }
    
    }

}

