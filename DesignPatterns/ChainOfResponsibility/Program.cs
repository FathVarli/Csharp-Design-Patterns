using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Belli şarta göre bizim devreye hangi nesneyi koyacağımızı gösterir.
            //Bu nesneler arasında hiyerarşi olması en önemli özelliğidir.
            //evrak takip sistemleri

            Manager manager = new Manager();
            VicePrisident vicePrisident = new VicePrisident();
            Prisident prisident = new Prisident();


            manager.SetSuccessor(vicePrisident);
            vicePrisident.SetSuccessor(prisident);

            Expense expense = new Expense { Detail = "Training", Amount = 102 };
            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail  { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class VicePrisident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount> 100 && expense.Amount<=1000)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class Prisident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
          
        }
    }
}
