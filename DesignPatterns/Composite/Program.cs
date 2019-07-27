using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            //bir kurumda çalışanlar ve çalışanların hiyerarşisini modellemede kullanılır.
            Employee fmv = new Employee { Name = "Fatih Varlı" };
            Employee zeynep = new Employee { Name = "Zeynep Varlı" };
            fmv.AddSubordinate(zeynep);//fatih için bir alt çalışan ekledik

            Employee irem = new Employee { Name = "İrem Varlı" };
            fmv.AddSubordinate(irem);

            Contractor derin = new Contractor { Name = "Derin" };
            irem.AddSubordinate(derin);

            Employee ali = new Employee { Name = "Ali Varlı" };
            zeynep.AddSubordinate(ali);
            Console.WriteLine(fmv.Name);
            foreach (Employee manager in fmv)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }
      }
    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        //foreachle gezebilmemiz için gerekli olan ortam enumerable

        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
