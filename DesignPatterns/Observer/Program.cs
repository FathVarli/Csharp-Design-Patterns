using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //sık kullanılır.
            //kendisine abone olan sistemlerin bir işlem olduğunda devreye girmesini sağlayan desen.
            //bir alışveriş sisteminde fiyatı düşen ürün hakkında bilgi almak
            var customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();


            Console.ReadLine();
        }
        class ProductManager
        {
            List<Observer> _observers = new List<Observer>();
            public void UpdatePrice()
            {
                Console.WriteLine("Prdocut price changed!");
                Notify();
            }

            public void Attach(Observer observer)
            {
                //parametre olarak gönderilen observerı ekler
                _observers.Add(observer);
            }

            public void Detach(Observer observer)
            {
                //parametre olarak gönderilen observerı çıkarır
                _observers.Remove(observer);
            }

            private void Notify()
            {
                //bilgilendirme yapılır
                foreach (var observer in _observers)
                {
                    observer.Update();
                }
            }

        }
        abstract class Observer
        {
            public abstract void Update(); //standart imza
        }
        class CustomerObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Message to Customer : Product price changed!");
            }
        }
        class EmployeeObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Message to Employee : Product price changed!");
            }
        }
    }
}
