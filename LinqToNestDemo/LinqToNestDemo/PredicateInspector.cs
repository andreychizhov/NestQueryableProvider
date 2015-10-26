using System.Linq.Expressions;

namespace LinqToNestDemo
{
    public class PredicateInspector : ExpressionVisitor
    {
        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            return base.VisitMemberAccess(m);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            return base.VisitMethodCall(m);
        }
    }
}
