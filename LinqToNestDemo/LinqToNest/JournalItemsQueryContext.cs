using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqToNestDemo
{
    internal sealed class JournalItemsQueryContext
    {
        internal static object Execute(Expression expression, Uri node)
        {
            var inspector = new PredicateInspector();

            SearchRequest sr = inspector.CreateRequestFromExpression(expression);

            return GetJournalItemsFromElastic(node, sr);
            
        }

        internal static IEnumerable<UAutoContractJournalItem> GetJournalItemsFromElastic(Uri node, SearchRequest request)
        {
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "uauto");


            var client = new ElasticClient(settings);


            var searchResult = client.Search<UAutoContractJournalItem>(request);

            return searchResult.Documents;
        }
    }
}
