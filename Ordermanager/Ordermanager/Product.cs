namespace Ordermanager_Logic
{
    public class Product
    {
        public string Name { get; }
        public double Price { get; private set; }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
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
