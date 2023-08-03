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
            a += "Price: " + price + "\n";
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
            for (int i = 0; i < maxVideoGame; i++)
            {
                s = s + videoGames[i].ToString() + "\n";
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
            s += getVideoGameList() + "\n";
            return s;
        }
    }
    class Program
    {
        static void Main()
        {
            VideoGameShop gameShop = new VideoGameShop("The Gang", "160 Kendal Ave","123-456-7890", 100);
            VideoGame game = null;

            // Read the file
            string[] lines = File.ReadAllLines("VideoGame.txt");

            // Print all the game have in file
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

            
            Console.WriteLine("This is my first game:" + gameShop.videoGames[0].getItemName());


            // Search by itemNumber
            // Console.WriteLine("Please input item number you want to search: ");
            // string userInput = Console.ReadLine();
            // int searchNumber = int.Parse(userInput);
            // for (int i = 0; i < lines.Length-1; i++)
            // {
            //     if (searchNumber == gameShop.videoGames[i].getItemNumber())
            //     {
            //         Console.WriteLine("This is the game you looking for: " + gameShop.videoGames[i].gameInfo());
            //         break;
            //     } else
            //     {
            //         Console.WriteLine("Please try again");
            //     }
            // }

            // Search by price
            Console.WriteLine("Please input price you want to search: ");
            string userInput1 = Console.ReadLine();
            int searchPrice = int.Parse(userInput1);
            for (int i = 0; i < lines.Length-1; i++)
            {
                if (searchPrice >= gameShop.videoGames[i].getPrice())
                {
                    Console.WriteLine("This is the game you looking for: " + gameShop.videoGames[i].gameInfo());
                } 
            }


            // Statistical analysis
            double sum = 0;
            double max = 0;
            double min = 0;
            for (int i = 0; i < lines.Length-1; i++)
            {
                sum = sum + gameShop.videoGames[i].getPrice();
                if( max < gameShop.videoGames[i].getPrice() )
                {
                    max = gameShop.videoGames[i].getPrice();
                }
                if (min > gameShop.videoGames[i].getPrice())
                {
                    min = gameShop.videoGames[i].getPrice();
                }
            }            
            double mean = sum / lines.Length;
            Console.WriteLine("This is the mean: " + mean);
            Console.WriteLine("This is the max number: " + max + "$");
            Console.WriteLine("This is the min number: " + min + "$");
        }
    }
}