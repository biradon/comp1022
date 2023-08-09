using System;
using System.IO;
using static System.Console;
using System.Text.RegularExpressions;

namespace Assignment2
{
    internal class VideoGame 
    {
        public int itemNumber;
        public string itemName;
        public double price;
        public double userRating;
        public int quantity;

        //Constructor of Video Game
        public VideoGame(int itemNumber, string itemName, double price, double userRating, int quantity)
        {
            this.itemNumber = itemNumber;
            this.itemName = itemName;
            this.price = price;
            this.userRating = userRating;
            this.quantity = quantity;
        }

        
        // Accessor of Video Game (getter)
        public int GetItemNumber()
        {
            return itemNumber;
        } 
        public string GetItemName()
        {
            return itemName;
        } 

        public double GetPrice()
        {
            return price;
        }

        public double GetUserRating()
        {
            return userRating;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        // Mutator of Video Game (setter)
        public void SetItemNumber(int newItemNumber)
        {
            itemNumber = newItemNumber;
        } 
        public void SetItemName(string newItemName)
        {
            itemName = newItemName;
        } 

        public void SetPrice(double newPrice)
        {
            price = newPrice;
        }

        public void SetUserRating(double newUserRating)
        {
            userRating = newUserRating;
        }

        public void SetQuantity(int newQuantity)
        {
            quantity = newQuantity;
        }

        // Print video game details info
        public string GameInfo()
        {
            string a = "\n**************************\n";
            a += "Game Number: " + itemNumber + "\n";
            a += "Name: " + itemName + "\n";
            a += "Price: " + price + "$" + "\n";
            a += "Rating: " + userRating + "\n";
            a += "In stock: " + quantity + "\n";
            a += "\n**************************\n";
            return a;
        }


    }

    class VideoGameShop
    {
        public string shopName;
        public string shopAddress;
        public string shopPhone;

        // Keep track the amount of Video game in the store
        public int amountVideoGame;

        // Maximum video game the store can have
        public int maxVideoGame;
        public VideoGame[] videoGames;

        public VideoGameShop(string shopName, string shopAddress, string shopPhone, int maxVideoGame )
        {
            this.shopName = shopName;
            this.shopAddress = shopAddress;
            this.shopPhone = shopPhone;
            this.maxVideoGame = maxVideoGame;
            amountVideoGame = 0;
            videoGames = new VideoGame[maxVideoGame];
        }

        // Get all the video game info and store in the video game array
        public void InitializeData()
        {
            // Read all the lines in the file
            string[] lines = File.ReadAllLines("VideoGames.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                // Split each element in 1 line become variable
                string[] fields = lines[i].Split(',');
                int itemNumber = int.Parse(fields[0]);
                double price = double.Parse(fields[2]);
                double userRating = double.Parse(fields[3]);
                int quantity = int.Parse(fields[4]);

                // Add variable to the VideoGame class
                VideoGame videoGame = new VideoGame(itemNumber, fields[1],price,userRating,quantity);
                
                // Add the video game to the gameShop
                this.AddVideoGame(videoGame);
            }
        }

        // Add Video Game
        public bool AddVideoGame (VideoGame a)
        {
            if (amountVideoGame < maxVideoGame)
            {
                videoGames[amountVideoGame] = a;
                amountVideoGame++;
                return true;
            }
            return false;
        }

        // Print the list of video 
        public string GetVideoGameList()
        {
            string s = "==== Video Game List ====\n";
            for (int i = 0; i < amountVideoGame; i++)
            {
                s = s + videoGames[i].GameInfo() + "\n";
            }
            s += "=========================\n";
            return s;
        }

        // Print the Shop info
        public string ShopInfo()
        {
            string s = "++++ Shop Info ++++\n";
            s += "Shop Name: " + shopName + "\n";
            s += "Location: " + shopAddress + "\n";
            s += "Phone Number: " + shopPhone + "\n";
            s += "+++++++++++++++++++++++++\n";
            return s;
        }

        // Find mean base on all the game in the store
        public void FindMean()
        {
            string[] lines = File.ReadAllLines("VideoGames.txt");
            double sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                sum += this.videoGames[i].GetPrice();
            }      
            double mean = Math.Round(sum / lines.Length, 2);
            Console.WriteLine("This is the mean: " + mean + "$" + "\n");
        }

        
        // Search for the item have highest price
        public void FindHighest()
        {
            string[] lines = File.ReadAllLines("VideoGames.txt");

            // Iterate to the video game array to find the highest price
            for (int i = 0; i< lines.Length; i++)
            {
                double max =  this.videoGames[i].GetPrice();
                int temp = i;
                // Nested 1 loop to compare 2 value i and i + 1
                for (int j = 1; j < lines.Length; j++)
                {
                    if( max < this.videoGames[j].GetPrice())
                    {
                        // Swap the index of higher price
                        temp = j;
                        max = this.videoGames[j].GetPrice();
                    }
                }
                Console.WriteLine("This is the highest item in the store");
                Console.WriteLine(this.videoGames[temp].GameInfo());
                i = lines.Length;
            }
        }

        // Search for the item have lowest price
        public void FindLowest()
        {
            string[] lines = File.ReadAllLines("VideoGames.txt");
            // Iterate to the video game array to find the lowest price
            for (int i = 0; i< lines.Length; i++)
            {
                double min =  this.videoGames[i].GetPrice();
                int temp = i;
                // Nested 1 loop to compare 2 value i and i + 1
                for (int j = 1; j < lines.Length; j++)
                {

                    if( min > this.videoGames[j].GetPrice())
                    {
                        // Swap the index of lower price
                        temp = j;
                        min = this.videoGames[j].GetPrice();
                    }
                }
                Console.WriteLine("This is the lowest item in the store");
                Console.WriteLine(this.videoGames[temp].GameInfo());
                i = lines.Length;
            }
        }

        // Search video game by price
        public void SearchByPrice()
        {
            double searchPrice;
            string[] lines = File.ReadAllLines("VideoGames.txt");
            Console.WriteLine("\n===========================================\n");
            Console.WriteLine("Hello, this feature will allow you to search for video games in the existing inventory based on maximum price");
            Console.WriteLine("Let's get start it!");
            Console.WriteLine("Please input price you want to search: ");

            // Validation of the input
            while(!double.TryParse(Console.ReadLine(), out searchPrice))
            {
                Console.WriteLine("Only input number, please try again");
            }
            bool found = false;

            // Iterate the video game array to find the price
            for (int i = 0; i < lines.Length; i++)
            {
                if (searchPrice >= this.videoGames[i].GetPrice())
                {
                    Console.WriteLine(this.videoGames[i].GameInfo());
                    found = true;
                } 
            }

            // If there is no item
            if (!found)
            {
                Console.WriteLine("Sorry, no item found");
            }
        }


        // Search video game by number
        public void SearchByNumnber()
        {
            string[] lines = File.ReadAllLines("VideoGames.txt");
            bool done = true;
            while (done)
            {        
                Console.WriteLine("Please input item number you want to search: \n");
                string? userInput = Console.ReadLine();

                // If user not input
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please input the item number!");
                    userInput = Console.ReadLine();
                }
                int searchNumber = int.Parse(userInput);
                bool found = false;

                // Iterate through the video game array to search an item number
                for (int i = 0; i < lines.Length; i++)
                {
                    if (searchNumber == this.videoGames[i].GetItemNumber())
                    {
                        Console.WriteLine("This is the game you looking for: " + this.videoGames[i].GameInfo());
                        done = false; // break the while loop
                        found = true; // To skip the condition of can not find
                        i = lines.Length; // break the for loop
                    }
                }

                // If there is no match item number
                if (!found)
                {
                    Console.WriteLine("Can not find the item");
                    Console.WriteLine("Please try again\n");
                }
            }
        }

        // Add new video game
        public void AddNewVideo()
        {
            string[] lines = File.ReadAllLines("VideoGames.txt");

            // Get the current directory
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "VideoGames.txt");

            // Set up for the validation loop
            bool validateItemNumber = true;
            bool validateItemName = true;
            bool validateItemPrice = true;
            bool validateItemRating = true;
            bool validateQuantity = true;

            // Setup for the input
            string? InputItemNumber = null;
            string? InputItemName = null;
            string? InputItemPrice = null;
            string? InputItemRating = null;
            string? InputItemQuantity = null;

            // Validate item number
            while(validateItemNumber)
            {
                Console.WriteLine("Please input the item number (only 4 digits)\n");
                InputItemNumber = Console.ReadLine();
                
                // In the case user not input, generate new number
                if (string.IsNullOrEmpty(InputItemNumber))
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1000, 9999);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        // Check duplicate item Number
                        if (randomNumber == this.videoGames[i].GetItemNumber())
                        {
                            randomNumber = random.Next(1000, 9999);
                        }
                        Console.WriteLine("The item number has been generated: " + randomNumber);
                        i = lines.Length;
                    }
                    InputItemNumber = randomNumber.ToString("D4");
                    validateItemNumber = false;
                }
                // Only allow number and with 4 digits
                else if (Regex.IsMatch(InputItemNumber,  @"^\d+$") && InputItemNumber.Length == 4)
                {
                    int newItemNumber = int.Parse(InputItemNumber);
                    bool found = true;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        // Check duplicate item Number
                        if (newItemNumber == this.videoGames[i].GetItemNumber())
                        {
                           Console.WriteLine("Your number is already exist, please choose another number!\n");
                           found = false;
                           i = lines.Length;
                        }
                        // If there is no exist number
                        if (found)
                        {
                            Console.WriteLine("Number is valid, let's continue with item name\n");
                            i = lines.Length;
                            validateItemNumber = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid! Please input number and only 4 digits\n");
                }
            }

            // Validate item name
            while(validateItemName)
            {
                Console.WriteLine("Please input the item name\n");
                InputItemName = Console.ReadLine();
                if (string.IsNullOrEmpty(InputItemName))
                {
                    Console.WriteLine("Invalid! Please input again");
                } else
                {
                    Console.WriteLine("Name is valid, let's continue with item price");
                    validateItemName = false;
                }
            }

            // Validate item price
            while(validateItemPrice)
            {
                double result;
                Console.WriteLine("Please input the item price\n");
                InputItemPrice = Console.ReadLine();
                if (double.TryParse(InputItemPrice, out result))
                {
                    Console.WriteLine("Price is valid, let's continue with item rating");
                    validateItemPrice = false;
                } else
                {
                    Console.WriteLine("Invalid, please try again with the correct format");
                    
                }
            }

            // Validate user rating
            while(validateItemRating)
            {
                double result;
                Console.WriteLine("Please rate your game (maximum is 5.0) \n");
                InputItemRating = Console.ReadLine();
                if (double.TryParse(InputItemRating, out result) && result <= 5)
                {
                    Console.WriteLine("Great! Rating is valid, let's move on to the last element");
                    validateItemRating = false;
                } else
                {
                    Console.WriteLine("Invalid, please try again with the correct format");
                    
                }
            }

            // Validate for quantity
            while(validateQuantity)
            {
                int result;
                Console.WriteLine("Please fill the quantity in the store\n");
                InputItemQuantity = Console.ReadLine();
                if (int.TryParse(InputItemQuantity, out result))
                {
                    Console.WriteLine("Great! Quantity is valid!");
                    validateQuantity = false;
                } else
                {
                    Console.WriteLine("Invalid, please only input number");
                    
                }
            }


            // Write the video game in the text file 
            using( StreamWriter outputFile = new StreamWriter(filePath, true))
            {
                outputFile.WriteLine($"{InputItemNumber}, {InputItemName}, {InputItemPrice}, {InputItemRating}, {InputItemQuantity}");
            }


            VideoGame game = new VideoGame(int.Parse(InputItemNumber), InputItemName, double.Parse(InputItemPrice), double.Parse(InputItemRating), int.Parse(InputItemQuantity));

            this.AddVideoGame(game);

            Console.WriteLine("\n***********Congratulation***********");
            Console.WriteLine("\nYou sucessfully added the new game to the store!");
            Console.WriteLine("\nYou just added: ");
            Console.WriteLine("\nGame number: " + InputItemNumber);
            Console.WriteLine("Name: " + InputItemName);
            Console.WriteLine("Price: " + InputItemPrice + "$");
            Console.WriteLine("Rating: " + InputItemRating);
            Console.WriteLine("In stock: " + InputItemQuantity);

        }
    }
    class Program
    {
        static void Main()
        {
            // Create an object for Shop
            VideoGameShop gameShop = new VideoGameShop("The Gang", "160 Kendal Ave","123-456-7890", 100);
            bool menu = true;

            // Add all of the game from file to the shop
            gameShop.InitializeData();


            // Introduction
            Console.WriteLine("Hello, Welcome to our shop");
            Console.WriteLine("This is our shop info\n");
            Console.WriteLine(gameShop.ShopInfo());
            Console.WriteLine("\nCould you let me know what's your name?");
            string? userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Please input the name!");
                userName = Console.ReadLine();
            }
            Console.WriteLine("Hi " + userName + " nice to meet you!");
            Console.WriteLine("This is how you can do in our shop, " + userName + " take your time in here");
            
            // Main menu
            while(menu)
            {
                Console.WriteLine("\nPlease click the number corresponding to which option you want to use:\n");
                Console.WriteLine("0. List all the video in shop");
                Console.WriteLine("1. Adding new Products");
                Console.WriteLine("2. Searching based on Item Number");
                Console.WriteLine("3. Searching based on Item Price");
                Console.WriteLine("4. Statiscal Info about Game");
                Console.WriteLine("5. Exit\n");
                int selectMenu;
                while(!int.TryParse(Console.ReadLine(), out selectMenu))
                {
                    Console.WriteLine("\nOnly input number, please try again\n");
                    Console.WriteLine("0. List all the video in shop");
                    Console.WriteLine("1. Adding new Products");
                    Console.WriteLine("2. Searching based on Item Number");
                    Console.WriteLine("3. Searching based on Item Price");
                    Console.WriteLine("4. Statiscal Info about Game");
                    Console.WriteLine("5. Exit\n");
                }
                switch(selectMenu)
                {
                    case 0:
                        Console.WriteLine(gameShop.GetVideoGameList());
                        break;
                    case 1:
                        gameShop.AddNewVideo();
                        break;
                    case 2:
                        gameShop.SearchByNumnber();
                        break;
                    case 3:
                        gameShop.SearchByPrice();
                        break;
                    case 4:
                        Console.WriteLine("\n===========================================\n");
                        Console.WriteLine("Hello, this feature will show you the mean, the highest game and lowest game in the shop");
                        Console.WriteLine("Let's get start it!\n");
                        gameShop.FindMean();
                        gameShop.FindHighest();
                        gameShop.FindLowest();
                        break;
                    case 5:
                        menu = false;
                        Console.WriteLine("\nThank you for coming to our shop, see you again, bye bye!\n");
                        break;
                    default:
                        Console.WriteLine("\nSorry, please try again, only input number from 1 to 5\n");
                        break;
                }
            }
        }
    }
}