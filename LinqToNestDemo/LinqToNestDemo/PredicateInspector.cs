using Nest;
using System;
using System.Linq.Expressions;

namespace LinqToNestDemo
{
    public class PredicateInspector : ExpressionVisitor
    {
        private string _term;
        private string _fieldName;

        //public PredicateInspector()
        //{

        //    //_container = new MatchQuery();
        //    //_request = new SearchRequest();
        //}

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            _fieldName = m.Member.Name;
            return base.VisitMemberAccess(m);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            //switch (m.Method.Name)
            //{
            //    case "Where":
            //        VisitLambda()
            //        break;
            //}
            if (m.Method.Name.Equals("StartsWith"))
            {
                _term = ((ConstantExpression)m.Arguments[0]).Value as String;
            }

            return base.VisitMethodCall(m);
        }

        internal SearchRequest CreateRequestFromExpression(Expression expression)
        {
            Visit(expression);

            QueryContainer query = new MatchQuery
            {
                Field = _fieldName,
                Query = _term
            };

            var searchRequest = new SearchRequest
            {
                From = 0,
                Size = 10,
                Query = query
            };

            return searchRequest;
        }
    }
}
