using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqToNest
{
    class JournalItemsProvider : IQueryProvider
    {
        private readonly Uri _node;

        public JournalItemsProvider(Uri node)
        {
            _node = node;
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return (IQueryable<TElement>) new JournalItemsContext<UAutoContractJournalItem>(this, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new JournalItemsContext<UAutoContractJournalItem>(this, expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            bool IsEnumerable = (typeof(TResult).Name == "IEnumerable`1");

            return (TResult)JournalItemsQueryContext.Execute(expression, _node, IsEnumerable);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return JournalItemsQueryContext.Execute(expression, _node, false);
        }
    }
}
