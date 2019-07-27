using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //ziyaretçi desene
            // birbirine benzeyen veya hiyerarşik nesnelerin birbirine benzeyen metodlarının biri üzerinden çağrılmasıdır
            Manager managerFatih = new Manager { Name = "Fatih", Salary = 1000 };
            Manager managerEngin = new Manager { Name = "Engin", Salary = 900 };

            Worker workerSalih = new Worker { Name = "Salih", Salary = 800 };
            Worker workerAli = new Worker { Name = "Ali", Salary = 700 };

            managerFatih.Subordinates.Add(managerEngin);
            managerEngin.Subordinates.Add(workerSalih);
            managerEngin.Subordinates.Add(workerAli);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(managerFatih);
            PayrolVisitor payrolVisitor = new PayrolVisitor();
            PayRiseVisitor payRiseVisitor = new PayRiseVisitor();

            organisationalStructure.Accept(payrolVisitor);
            organisationalStructure.Accept(payRiseVisitor);

            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor) //temel method
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set;}

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }

        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrolVisitor : VisitorBase
    {

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class PayRiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }
}
