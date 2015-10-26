using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using LinqToNestDemo;

namespace ODataWithElasticDemo.Controllers
{
    public class JournalItemsController : ODataController
    {
        private JournalItemsContext ctx = new JournalItemsContext(new Uri("http://devpro.ugsk.ru:9200"));

        [EnableQuery]
        public IQueryable<UAutoContractJournalItem> Get()
        {
            return ctx.Where(item => item.EmployeeName.StartsWith("Петров"));
        }
    }
}
