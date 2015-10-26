using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using ODataWithElasticDemo.Models;

namespace ODataWithElasticDemo.Controllers
{
    public class JournalItemsController : ODataController
    {
        [EnableQuery]
        public IQueryable<UAutoContractJournalItem> Get()
        {
            return Enumerable.Empty<UAutoContractJournalItem>().AsQueryable();
        }
    }
}
