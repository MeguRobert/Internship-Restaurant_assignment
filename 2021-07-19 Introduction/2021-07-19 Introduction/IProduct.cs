namespace _2021_07_19_Introduction
{
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int Quantity { get; set; }
        bool IsDisponible { get; }

        
    }
}