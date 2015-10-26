using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqToNestDemo
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
            return (IQueryable<TElement>) new JournalItemsContext(this, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new JournalItemsContext(this, expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return (TResult)JournalItemsQueryContext.Execute(expression, _node);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return Execute<UAutoContractJournalItem>(expression);
        }
    }
}
