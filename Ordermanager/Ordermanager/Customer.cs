namespace Ordermanager_Logic
{
    public class Customer
    {
        public string Name { get; }
        public string Adress { get; }

        public Customer(string name, string adress)
        {
            this.Name = name;
            this.Adress = adress;
        }

        //public override string ToString()
        //{
        //    string result;
        //    result = "Name: " + name + "\n";
        //    result += "Adress: " + adress;

        //    return result;
        //}
    }
}
