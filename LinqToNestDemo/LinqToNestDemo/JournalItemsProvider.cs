using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqToNestDemo
{
    class JournalItemsProvider : IQueryProvider
    {
        public JournalItemsProvider(Uri node)
        {

        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return (IQueryable<TElement>) new JournalItemsContext(this, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new JournalItemsContext(this, expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            var isEnumerable = (typeof(TResult).Name == "IEnumerable`1");
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return Execute<UAutoContractJournalItem>(expression);
        }
    }
}
