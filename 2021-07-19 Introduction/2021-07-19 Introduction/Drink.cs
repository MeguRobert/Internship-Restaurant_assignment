namespace _2021_07_19_Introduction
{
    class Drink : IProduct
    {

        public Drink(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDisponible {
            get
            {
                if (Quantity > 0) return true;
                else return false;
            }
        }

        public override string ToString()
        {
            return $"{Name}{"........................................",30} {Price} lei\n";
            
        }
        //TODO dose
    }
}
