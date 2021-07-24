namespace _2021_07_19_Introduction
{
    class Food : IProduct
    {

        public Food(string name, string ingredients, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Ingredients = ingredients;
        }

        //interface props
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDisponible
        {
            get
            {
                if (Quantity > 0) return true;
                else return false;
            }
        }

        //own props
        public string Ingredients { get; set; }

        public override string ToString()
        {
            return $"{Name}{"........................................",10} {Price} lei \n{Ingredients}\n";
        }
    }
}
