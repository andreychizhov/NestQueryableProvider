using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqToNest
{
    public class JournalItemsContext<UAutoContractJournalItem> : IOrderedQueryable<UAutoContractJournalItem>
    {
        public JournalItemsContext(Uri nodeUri)
        {
            Provider = new JournalItemsProvider(nodeUri);
            Expression = Expression.Constant(this);
        }

        public JournalItemsContext(IQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof(IQueryable<UAutoContractJournalItem>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            Provider = provider;
            Expression = expression;
        }

        public IEnumerator<UAutoContractJournalItem> GetEnumerator()
        {
            return Provider.Execute<IEnumerable<UAutoContractJournalItem>>(Expression).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(UAutoContractJournalItem); }
        }

        public Expression Expression { get; private set; }

        public IQueryProvider Provider { get; private set; }
    }
}
