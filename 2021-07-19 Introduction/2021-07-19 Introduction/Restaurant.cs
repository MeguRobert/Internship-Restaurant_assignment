using System;
using System.Collections.Generic;
using System.Threading;

namespace _2021_07_19_Introduction
{
    class Restaurant
    {
        private static Random rnd = new Random();

        public static List<IProduct> menu = new List<IProduct>();
        public static List<Waiter> waiters = new List<Waiter>();
        public static Waiter disponibleWaiter = null;


        private static double minimumWaitingTime;
        private const int NUMBER_OF_WAITERS = 5;
        public static string order = "";
        public static double price = 0;

        public static void Open() //R
        {

            for (int i = 0; i < NUMBER_OF_WAITERS; i++)
            {
                waiters.Add(new Waiter());
            }

            CreateMenu();
            GiveTasksToWaiters();
        }

        public static void Enter() //C
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                          W E L L C O M E    T O    G A B R I E L     R E S T A U R A N T ! ");
            Console.ForegroundColor = ConsoleColor.White;

            while (!IsThereAWaiterAvailable())
            {
                Console.WriteLine("Sorry, all the waiters are busy.");
                minimumWaitingTime = MinimumWaitingTime();
                Console.WriteLine($"A waiter will be available in {minimumWaitingTime} minutes.");
                SimulateTimeElapse();
            }
            GetAWaiter();

            GetTheBill();

        }

        private static void GetTheBill()//C
        {
            Console.WriteLine($"You have to pay {price} lei");
        }

        private static void GetAWaiter() //C
        {
            try
            {
                disponibleWaiter = GetFirstDisponibleWaiter();
                Console.WriteLine("         Hello! Here is the menu:");
                disponibleWaiter.ShowTheMenu();
                Thread.Sleep(2000);
                Console.WriteLine("What can I bring for you?");
                Ordering(); //Client.Ordering();
                GetTheOrder();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetTheOrder()//C
        {
            Console.WriteLine($"Here is your {order}");
        }

        private static Waiter GetFirstDisponibleWaiter() //R
        {
            for (int i = 0; i < waiters.Count; i++)
            {
                if (waiters[i].IsDisponible) return waiters[i];
            }
            return waiters[-1];
        }


        private static void SimulateTimeElapse() //R+
        {
            int minutes = rnd.Next(10);

            foreach (var waiter in waiters)
            {
                waiter.TaskDurationInMinutes -= minutes; 
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine($"\n{minutes} minutes later...");
        }

        private static bool IsThereAWaiterAvailable()//R
        {
            foreach (Waiter waiter in waiters)
            {
                if (waiter.IsDisponible) return true;
            }
            return false;
        }

        private static double MinimumWaitingTime()//R+
        {
            double min = 60;
            foreach (Waiter waiter in waiters)
            {
                if (waiter.TaskDurationInMinutes < min) return min = waiter.TaskDurationInMinutes;
            }

            return min;
        }

        private static void CreateMenu() //R
        {
            menu.Add(new Food("BURGER", "Toasted Bun, Cheddar Cheese, Lettuce, Tomato, Onion", 13, 10));
            menu.Add(new Food("PIZZA full of pepperoni" , "Mozzarella, Parmesan", 24, 6));
            menu.Add(new Food("PIZZA BBQ Chicken" , "House BBQ, Mozzarella, Cilantro, Caramelized Onion", 24, 8));

            menu.Add(new Drink("COLA", 6.5, 9));
            menu.Add(new Drink("SWEPPES", 6.0, 5));
            menu.Add(new Drink("LEMONADE", 9.0, 7));
        }
        
        private static void GiveTasksToWaiters() //R
        {
            foreach (Waiter waiter in waiters)
            {
                int duration = rnd.Next(0, 30);
                waiter.TaskDurationInMinutes = duration < 0 ? 0 : duration;
            }
        }


        public static void Ordering() //C
        {
            bool theClientWantToOrderSomethingElse;
            do
            {
                Console.WriteLine("Please write the name of the food or drink what you want to order. ");
                string input = Console.ReadLine();
                NoteTheOrder(input);
                Console.WriteLine("Anything else? (type yes or no)");
                string response = Console.ReadLine().ToLower();
                theClientWantToOrderSomethingElse = response == "yes";


            } while (theClientWantToOrderSomethingElse);

        }


        private static void NoteTheOrder(string productName) //W
        {
            foreach (var product in menu)
            {
                if (product.Name.ToUpper() == productName.ToUpper() && product.IsDisponible)
                {
                    product.Quantity--;
                    price += product.Price;
                    order += productName + Environment.NewLine;
                }
            }
        }
    }
}
