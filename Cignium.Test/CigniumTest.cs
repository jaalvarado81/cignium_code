using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CigniumBE;
using CigniumBL;
using System.Collections.Generic;

namespace Cignium.Test
{
    [TestClass]
    public class CigniumTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string query = "\"this is a test\" about get \"hola\" esta prueba";

            List<string> queries = SearchBL.getQueries(query);

            Assert.Equals(queries.Count, 6);

            List<searchResult> result = SearchBL.search(query);


        }
    }
}
