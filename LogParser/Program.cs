using System;
using System.Collections.Generic;
using System.IO;

namespace LogParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReportingTools rpt = new ReportingTools();
            var path = Path.Combine(Environment.CurrentDirectory + @"\TestData\test2.txt");
            Console.WriteLine("Request Stats:");
            //Parse log file for just the data we're interested in i.e. IPs and URLs
            List<Request> requests = rpt.GetRequests(path);

            //Number of unique IP Addresses:
            Console.WriteLine("Number of Unique IPs: {0}", rpt.UniqueIpCount(requests));

            //Top 3 most frequently visited urls
            List<string> topUrls = rpt.ListTopUrls(requests);
            Console.WriteLine("The Top 3 most visited URLs are:");
            Console.WriteLine(topUrls[0]);
            Console.WriteLine(topUrls[1]);
            Console.WriteLine(topUrls[2]);

            //Top 3 most active IP adresses:
            List<string> topIps = rpt.ListTopIps(requests);
            Console.WriteLine("The Top 3 most active IP addresses are:");
            Console.WriteLine(topIps[0]);
            Console.WriteLine(topIps[1]);
            Console.WriteLine(topIps[2]);

            Console.WriteLine("Done");

        }

        
    }
}
