using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqToNest
{
    internal class ExpressionTreeModifier : System.Linq.Expressions.ExpressionVisitor
    {
        private IQueryable<UAutoContractJournalItem> queryableJournalItems;

        internal ExpressionTreeModifier(IQueryable<UAutoContractJournalItem> items)
        {
            this.queryableJournalItems = items;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c.Type == typeof(JournalItemsContext<UAutoContractJournalItem>))
                return Expression.Constant(this.queryableJournalItems);
            else
                return c;
        }
    }
}
