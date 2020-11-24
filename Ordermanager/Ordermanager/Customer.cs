namespace Ordermanager_Logic
{
    public class Customer
    {
        public string name { get; }
        public string adress { get; }

        public Customer(string name, string adress)
        {
            this.name = name;
            this.adress = adress;
        }

        public override string ToString()
        {
            string result;
            result = "Name: " + name + "\n";
            result += "Adress: " + adress;

            return result;
        }
    }
}
