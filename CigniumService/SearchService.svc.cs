using CigniumBE;
using CigniumBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CigniumService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SearchService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SearchService.svc or SearchService.svc.cs at the Solution Explorer and start debugging.
    public class SearchService : ISearchService
    {
        public List<searchResult> processSearch(string query)
        {
            return SearchBL.search(query);
        }
    }
}
