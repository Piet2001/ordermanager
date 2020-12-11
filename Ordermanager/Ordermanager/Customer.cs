namespace Ordermanager_Logic
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; }
        public string Adress { get; }

        public Customer(int id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;
        }
        public Customer(string name, string adress)
        {
            this.Name = name;
            this.Adress = adress;
        }
        public Customer()
        {

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
