using System;

namespace _2021_07_19_Introduction
{
    class Waiter
    {
        public int TaskDurationInMinutes { get; set; }
        public bool IsDisponible {
            get
            {
                if (TaskDurationInMinutes == 0)
                    return true;
                else return false;
            } 
        }

        public void ShowTheMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                  M E N U");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var product in Restaurant.menu)
            {
                Console.WriteLine(product);
            }
        }
        private static void NoteTheOrder(string productName)
        {
            
            foreach (var product in Restaurant.menu)
            {
                if (product.Name.ToUpper() == productName.ToUpper() && product.IsDisponible)
                {
                    product.Quantity--;
                    Restaurant.price += product.Price;
                    Restaurant.order += productName + Environment.NewLine;
                }
            }

            
        }
    }
}