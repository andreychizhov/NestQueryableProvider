using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqToNest
{
    internal sealed class JournalItemsQueryContext
    {
        internal static object Execute(Expression expression, Uri node, bool isEnumerable)
        {
            var inspector = new ODataQueryInspector();

            SearchRequest sr = inspector.CreateRequestFromExpression(expression);

            IQueryable<UAutoContractJournalItem> records = GetJournalItemsFromElastic(node, sr);

            ExpressionTreeModifier treeCopier = new ExpressionTreeModifier(records);
            Expression newExpressionTree = treeCopier.Visit(expression);

            if (isEnumerable)
                return records.Provider.CreateQuery(newExpressionTree);
            else
                return records.Provider.Execute(newExpressionTree);
        }

        internal static IQueryable<UAutoContractJournalItem> GetJournalItemsFromElastic(Uri node, SearchRequest request)
        {
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "uauto");


            var client = new ElasticClient(settings);


            var searchResult = client.Search<UAutoContractJournalItem>(request);

            return searchResult.Documents.AsQueryable();
        }
    }
}
