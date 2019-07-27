using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //İş katmanında sık kullanılır
            //Bir strateji belirleyip o strateji üzerinden metodların kullanılmasıdır
            CustomerManager customerManager = new CustomerManager();
            customerManager.creditCalculatorBase = new Before2010CrediCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CrediCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }
    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase creditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            creditCalculatorBase.Calculate();
        }
    }
}
