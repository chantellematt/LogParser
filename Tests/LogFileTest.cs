using LogParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests
{
    [TestClass]
    public class LogFileTest
    {
        [TestMethod]
        public void Test1()
        {            
            string file = Path.Combine(Environment.CurrentDirectory + @"\TestData\test1.txt");
            ReportingTools rpt = new ReportingTools();
            List<Request> requests = rpt.GetRequests(file);
            int uniqueIps = rpt.UniqueIpCount(requests);
            List<string> topUrls = rpt.ListTopUrls(requests);
            List<string> topIps = rpt.ListTopIps(requests);
            Assert.AreEqual(11, uniqueIps);
            CollectionAssert.Contains(topUrls, "/docs/manage-websites/");
            CollectionAssert.Contains(topIps, "168.41.191.40");
        }

        [TestMethod]
        public void Test2()
        {
            string file = Path.Combine(Environment.CurrentDirectory + @"\TestData\test2.txt");
            ReportingTools rpt = new ReportingTools();
            List<Request> requests = rpt.GetRequests(file);
            int uniqueIps = rpt.UniqueIpCount(requests);
            List<string> topUrls = rpt.ListTopUrls(requests);
            List<string> topIps = rpt.ListTopIps(requests);
            Assert.AreEqual(7, uniqueIps);
            CollectionAssert.Contains(topUrls, "http://example.net/blog/category/meta/");
            CollectionAssert.Contains(topUrls, "/asset.js");
            CollectionAssert.Contains(topUrls, "/intranet-analytics/");
            CollectionAssert.DoesNotContain(topUrls, "http://example.net/faq/");
            CollectionAssert.Contains(topIps, "168.41.191.40");
            CollectionAssert.Contains(topIps, "168.41.191.41");
            CollectionAssert.Contains(topIps, "177.71.128.21");
            CollectionAssert.DoesNotContain(topIps, "50.112.00.11");
        }
    }

}
