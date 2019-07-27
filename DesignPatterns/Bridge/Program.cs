using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //bir nesnenin içerisinde soyutlanabilir yani değiştirilebilir kısımlar varsa onları soyutlama teknikleriyle kullanmak
            CustomerManager customerManager = new CustomerManager();
            customerManager.messageSenderBase = new EmailSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

   abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Massage saved!");
        }
        public abstract void Send(Body body);
    }

     class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via SmsSender!", body.Title);
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via EmailSender!", body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase messageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            messageSenderBase.Send(new Body { Title = "About the Course" });
            Console.WriteLine("Customer updated!");
        }
    }
}
