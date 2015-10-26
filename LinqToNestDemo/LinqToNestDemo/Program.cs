using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToNestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Uri("http://devpro.ugsk.ru:9200");

            var context = new JournalItemsContext(node);
            System.Linq.Expressions.Expression<Func<UAutoContractJournalItem, bool>> filter = item => item.EmployeeName.StartsWith("Иванов");
            var items = context.Where(filter);


            Console.WriteLine("{0} was found (OIS)", items.ToArray().Length);
            Console.ReadLine();
        }
    }
}
