using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Composite Deseniyle Hiyerarşik Yapı Örneği");
            Employee mert = new Employee {Name = "Mert"};
            Employee damla = new Employee { Name = "Damla" };
            mert.AddSubordinate(damla);

            Employee gizem = new Employee { Name = "Gizem" };
            mert.AddSubordinate(gizem);

            Employee merve = new Employee {Name = "Merve"};
            damla.AddSubordinate(merve);

            Console.WriteLine("Mert");
            foreach (Employee manager in mert)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        private List<IPerson> _subordinates = new List<IPerson>(); //Hiyerarşide alt kademe

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void DeleteSubordinate(IPerson person)
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
