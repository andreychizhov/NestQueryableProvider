using Nest;
using System;
using System.Linq;
using System.Linq.Expressions;
//using System.Web.OData.Query.Expressions;

namespace LinqToNest
{
    public class ODataQueryInspector : ExpressionVisitor
    {
        private string _term;
        private string _fieldName;

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            switch (m.Member.Name)
            {
                case "EmployeeName":
                    _fieldName = m.Member.Name;
                    break;
                default:
                    break;
            }

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
                if (m.Arguments[0].NodeType == ExpressionType.Constant)
                {
                    _term = ((ConstantExpression)m.Arguments[0]).Value as String;
                }
            }

            return base.VisitMethodCall(m);
        }

        //protected override Expression VisitConstant(ConstantExpression c)
        //{
        //    ////if (m.Arguments[0].NodeType == ExpressionType.Constant)
        //    //{
        //        dynamic arg = c.Value;
        //        if (c.Value == null || arg.ToString().Contains("Nest")) return base.VisitConstant(c);
        //        string val = arg.TypedProperty as string;
        //        if (val != null)
        //            _term = val;//((ConstantExpression)m.Arguments[0]).Value as String;
        //    //}
        //    return base.VisitConstant(c);
        //}

        internal SearchRequest CreateRequestFromExpression(Expression expression)
        {
            Visit(expression);

            QueryContainer query = new MatchQuery
            {
                Field = ToCamelCase(_fieldName),
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

        private string ToCamelCase(string property)
        {
            return property.Substring(0, 1).ToLower() + property.Substring(1);
        }
    }
}
