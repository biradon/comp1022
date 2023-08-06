using System;
using System.IO;
using static System.Console;

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
        public int getItemNumber()
        {
            return itemNumber;
        } 
        public string getItemName()
        {
            return itemName;
        } 

        public double getPrice()
        {
            return price;
        }

        public double getUserRating()
        {
            return userRating;
        }

        public int getQuantity()
        {
            return quantity;
        }

        // Mutator of Video Game (setter)
        public void setItemNumber(int newItemNumber)
        {
            itemNumber = newItemNumber;
        } 
        public void setItemName(string newItemName)
        {
            itemName = newItemName;
        } 

        public void setPrice(double newPrice)
        {
            price = newPrice;
        }

        public void setUserRating(double newUserRating)
        {
            userRating = newUserRating;
        }

        public void getQuantity(int newQuantity)
        {
            quantity = newQuantity;
        }

        // Print video details info
        public string gameInfo()
        {
            string a = "\n**************************\n";
            a += "Game Number: " + itemNumber + "\n";
            a += "Name: " + itemName + "\n";
            a += "Price: " + price + "$" + "\n";
            a += "Rating: " + userRating + "\n";
            a += "In stock: " + quantity + "\n";
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

        // Add Video Game
        public bool addVideoGame (VideoGame a)
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
        public string getVideoGameList()
        {
            string s = "==== Video Game List ====\n";
            for (int i = 0; i < amountVideoGame; i++)
            {
                s = s + videoGames[i].gameInfo() + "\n";
            }
            return s;
        }

        // Print the Shop info
        public string shopInfo()
        {
            string s = "++++ Shop Info ++++\n";
            s += "Shop Name: " + shopName + "\n";
            s += "Location: " + shopAddress + "\n";
            s += "Phone Number: " + shopPhone + "\n";
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            VideoGameShop gameShop = new VideoGameShop("The Gang", "160 Kendal Ave","123-456-7890", 100);
            VideoGame game = null;
            bool menu = true;

            string[] lines = File.ReadAllLines("VideoGame.txt");
            for (int i = 0; i < lines.Length-1; i++)
            {
                // Split each element in 1 line become variable
                string[] fields = lines[i].Split(',');
                int itemNumber = int.Parse(fields[0]);
                double price = double.Parse(fields[2]);
                double userRating = double.Parse(fields[3]);
                int quantity = int.Parse(fields[4]);

                // Add variable to the VideoGame class
                game = new VideoGame(itemNumber, fields[1],price,userRating,quantity);
                
                // Add the video to the gameShop
                gameShop.addVideoGame(game);
            }
            
            


            Console.WriteLine("Hello, Welcome to our shop");
            Console.WriteLine("This is our shop info\n");
            Console.WriteLine(gameShop.shopInfo());
            Console.WriteLine("\nCould you let me know what's your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hi " + userName + " nice to meet you!");
            Console.WriteLine("This is how you can do in our shop, " + userName + " take your time in here");
            while(menu)
            {
                Console.WriteLine("\nPlease click the number correcsponde to which option you want to use: \n");
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
                        Console.WriteLine(gameShop.getVideoGameList());
                        break;
                    case 1:
                        // Code go here
                        break;
                    case 2:
                        searchByNumnber(lines, gameShop);
                        break;
                    case 3:
                        searchByPrice(lines, gameShop);
                        break;
                    case 4:
                        Console.WriteLine("\n===========================================\n");
                        Console.WriteLine("Hello, this feature will show you the mean, the highest game and lowest game in the shop");
                        Console.WriteLine("Let's get start it!\n");
                        findMean(lines, gameShop);
                        findHighest(lines, gameShop);
                        findLowest(lines, gameShop);
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


        // Search by itemNumber
        static void searchByNumnber(string[] lines, VideoGameShop gameShop)
        {
        bool found = true;
        while (found)
        {        
            Console.WriteLine("Please input item number you want to search: \n");
            string userInput = Console.ReadLine();
            int searchNumber = int.Parse(userInput);
            for (int i = 0; i < lines.Length-1; i++)
            {
                if (searchNumber == gameShop.videoGames[i].getItemNumber())
                {
                    Console.WriteLine("This is the game you looking for: " + gameShop.videoGames[i].gameInfo());
                    found = false; // break the while loop
                    i = lines.Length-1; // break the for loop
                }
                if (found)
                {
                    Console.WriteLine("Can not find the item");
                    Console.WriteLine("Please try again\n");
                }
            }
        }
        }

        // Search by price
        static void searchByPrice(string[] lines, VideoGameShop gameShop)
        {
            Console.WriteLine("\n===========================================\n");
            Console.WriteLine("Hello, this feature will allow you to search for video games in the existing inventory based on maximum price");
            Console.WriteLine("Let's get start it!");
            Console.WriteLine("Please input price you want to search: ");
            int searchPrice;
            while(!int.TryParse(Console.ReadLine(), out searchPrice))
            {
                Console.WriteLine("Only input number, please try again");
            }
            bool found = false;
            for (int i = 0; i < lines.Length-1; i++)
            {
                if (searchPrice >= gameShop.videoGames[i].getPrice())
                {
                    Console.WriteLine(gameShop.videoGames[i].gameInfo());
                    found = true;
                } 
            }
            if (!found)
            {
                Console.WriteLine("Sorry, no item found");
            }
        }



        // Statistical analysis
        // Calculate the mean
        static void findMean(string[] lines, VideoGameShop gameShop)
        {
            double sum = 0;
            for (int i = 0; i < lines.Length-1; i++)
            {
                sum = sum + gameShop.videoGames[i].getPrice();
            }      
            double mean = sum / lines.Length;
            Console.WriteLine("This is the mean: " + mean + "$" + "\n");
        }

        // Search for the item have highest price
        static void findHighest(string[] lines, VideoGameShop gameShop)
        {
            for (int i = 0; i< lines.Length-1; i++)
            {
                double max =  gameShop.videoGames[i].getPrice();
                int temp = i;
                for (int j = 1; j < lines.Length-1; j++)
                {
                    if( max < gameShop.videoGames[j].getPrice())
                    {
                        temp = j;
                        max = gameShop.videoGames[j].getPrice();
                    }
                }
                Console.WriteLine("This is the highest item in the store");
                Console.WriteLine(gameShop.videoGames[temp].gameInfo());
                i = lines.Length - 1;
            }
        }



           // Search for the item have lowest price
        static void findLowest(string[] lines, VideoGameShop gameShop)
        {
            for (int i = 0; i< lines.Length-1; i++)
            {
                double min =  gameShop.videoGames[i].getPrice();
                int temp = i;
                for (int j = 1; j < lines.Length-1; j++)
                {

                    if( min > gameShop.videoGames[j].getPrice())
                    {
                        temp = j;
                        min = gameShop.videoGames[j].getPrice();
                    }
                }
                Console.WriteLine("This is the lowest item in the store");
                Console.WriteLine(gameShop.videoGames[temp].gameInfo());
                i = lines.Length - 1;
            }
        }
    }
}









        