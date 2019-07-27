using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //maliyeti minimize etmek için kullanılır.Temel sınıftan başka sınıflar klonlarken kullanılır.
            Customer customer1 = new Customer { FirstName = "Fatih", LastName = "Varlı",City="Kırıkkale",Id=1 };
            

            Customer customer2 = (Customer)customer1.CLone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();

        }
    }
    public abstract class Person
    {
        public abstract Person CLone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Customer : Person
    {
        public string City { get; set; }

        public override Person CLone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
