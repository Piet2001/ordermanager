namespace Ordermanager_Logic
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public double Price { get; private set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;

        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public Product(int id, double price)
        {
            Id = id;
            Price = price;
        }

        public Product()
        {

        }
        public void UpdatePrice(double newprice)
        {
            Price = newprice;
        }

        public override string ToString()
        {
            string result;
            result = "Name: " + Name + "\n";
            result += "Price: " + Price;

            return result;
        }
    }
}
