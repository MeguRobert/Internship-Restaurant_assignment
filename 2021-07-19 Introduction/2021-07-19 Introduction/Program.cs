using System;

namespace _2021_07_19_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant.Open();
            Console.WriteLine("Would you like a cold drink, or a delicious meal? ( type 'yes' or 'no' )");
            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Restaurant.Enter();
            }
            else
            {
                Console.WriteLine("Your choice!");
            }
        }
    }
}
