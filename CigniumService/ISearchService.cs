using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CigniumBE;

namespace CigniumService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISearchService" in both code and config file together.
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/processSearch?query={query}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<searchResult> processSearch(string query);
    }
}
