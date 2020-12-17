namespace Ordermanager_Logic
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public double Price { get; private set; }

        public Product(string name, double price, int id = 0)
        {
            Id = id;
            Name = name;
            Price = price;

        }

        //public override string ToString()
        //{
        //    string result;
        //    result = "Name: " + Name + "\n";
        //    result += "Price: " + Price;

        //    return result;
        //}
    }
}
