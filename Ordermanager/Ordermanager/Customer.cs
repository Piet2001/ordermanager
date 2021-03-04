namespace Ordermanager_Logic
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; }
        public string Adress { get; }

        public Customer(string name, string adress, int id = 0)
        {
            Id = id;
            Name = name;
            Adress = adress;
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
