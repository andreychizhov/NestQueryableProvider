using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToNest;

namespace LinqToNestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Uri("http://devpro.ugsk.ru:9200");

            var context = new JournalItemsContext<UAutoContractJournalItem>(node);

            var items = context.Where(item => item.EmployeeName.StartsWith("Иванов"));

            foreach (var item in items)
            {
                Console.WriteLine(item.EmployeeName);
            }
            Console.WriteLine("{0} was found (OIS)", items.ToArray().Length);
            Console.ReadLine();
        }
    }
}
