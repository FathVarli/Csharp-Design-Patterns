using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bir nesneyi sürekli kullanmamız gereken durumlarda yapılır.
            //Kesinlikle ve kesinlike bir kere üretildiğinden emin oluyoruz.
            var customerManager= CustomerManager.CreateAsSingleton();
            customerManager.Saved();
        }
    }

    class CustomerManager
    {
        static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)//birden fazla kullanıcı tarafından aynı nesneden birden fazla üretilmesini engellemek için kullanılır.
            {
                if (_customerManager==null)
                 {
                    _customerManager = new CustomerManager();
                 }
            }
                 return _customerManager;
        }
        public void Saved()
        {
            Console.WriteLine("Saved!");
        }


    }
}
