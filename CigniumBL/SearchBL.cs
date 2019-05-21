using CigniumBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CigniumBL
{
    public class SearchBL
    {
        private static readonly Random random = new Random();

        private static Int32 RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return Convert.ToInt32(minValue + (next * (maxValue - minValue)));
        }

        private static searchResult searchInEngine(SearchEngines engine, string query )
        {
            searchResult respResult = null;

            System.IO.Stream newStream = null;
            System.Net.WebResponse response = null;
            System.IO.StreamReader reader = null;

            try
            {
                /* 
                 * An example to call to the search engine directly
                 * 
                string url = String.Format("{0}?q={1}", engine.url, query);

                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                wr.Method = "GET";
                wr.ContentType = "application/x-www-form-urlencoded";

                response = wr.GetResponse();
                newStream = response.GetResponseStream();

                reader = new System.IO.StreamReader(newStream);
                string responseFromServer = reader.ReadToEnd();
                */
                /*This is for test purpose*/
                respResult = new searchResult();
                respResult.engine = engine.name;
                switch (engine.name)
                {
                    case "google":
                        respResult.resultsCount = RandomNumberBetween(1000,5000);
                        respResult.search = query;
                        break;
                    case "yahoo":
                        respResult.resultsCount = RandomNumberBetween(1000, 5000);
                        respResult.search = query;
                        break;
                    case "bing":
                        respResult.resultsCount = RandomNumberBetween(1000, 5000);
                        respResult.search = query;
                        break;
                    default:
                        respResult.resultsCount = 0;
                        respResult.search = query;
                        break;
                }

            }            
            catch (Exception ex)
            {
                //Log error
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (newStream != null)
                    newStream.Close();

                if (response != null)
                    response.Close();
            }

            return respResult;
        }

        //put this public in order to test
        public static List<string> getQueries(string query)
        {
            //determinate the queries.
            var queriesWithQuotes = Regex.Matches(query, "\\\"(.*?)\\\"");
            List<string> queries = new List<string>();

            foreach (var item in queriesWithQuotes)
            {
                query = query.Replace(item.ToString(), string.Empty);
                queries.Add(item.ToString());
            }

            string[] words = query.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                queries.Add(word.ToString());
            }
            return queries;
        }
                
        public static List<searchResult> search(string query)
        {
            List<SearchEngines> searchEngines = SingletonEngines.Instance.searchEngines;
            List<searchResult> results = new List<searchResult>();
            List<searchResult> winners = new List<searchResult>();

            List<string> queries = getQueries(query);

            foreach (var engine in searchEngines)
            {
                results = new List<searchResult>();

                foreach (var item in queries)
                {
                    searchResult result = searchInEngine(engine, item.ToString());
                    results.Add(result);
                }

                var winnerByEngine = results.OrderByDescending(x => x.resultsCount).FirstOrDefault();

                winnerByEngine.engine = winnerByEngine.engine + " winner";

                winners.Add(winnerByEngine);
            }

            searchResult winner = winners.OrderByDescending(x => x.resultsCount).FirstOrDefault();

            searchResult winnerAdd = winner.Clone() as searchResult;

            winnerAdd.engine = "Total winner";

            winners.Add(winnerAdd);

            return winners;
        }
    }

    
}
