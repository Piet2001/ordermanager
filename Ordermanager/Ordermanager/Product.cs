namespace Ordermanager_Logic
{
    public class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public void UpdatePrice(double newprice)
        {
            price = newprice;
        }

        public override string ToString()
        {
            string result;
            result = "Name: " + name + "\n";
            result += "Price: " + price;

            return result;
        }
    }
}
