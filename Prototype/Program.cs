using System;

namespace Prototype

//Amaç nesne üretim maliyetlerini minimize etmektir.
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer {FirstName = "Mert", LastName = "Aksoy", City = "İstanbul", Id = 1};

            Customer customer2 = (Customer) customer1.Clone();
            customer2.FirstName = "Can";
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Customer : Person
    {
        public string City { get; set; }


        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }


        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
