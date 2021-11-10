using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogParser
{
    public class ReportingTools
    {
        /// <summary>
        /// Parses the input file for request data and returns it as a list
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Request> GetRequests(string path)
        {
            List<Request> requests = new List<Request>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var log = Regex.Split(line, " ");
                    requests.Add(new Request(log[0], log[6]));
                }
            }
            return requests;
        }

        /// <summary>
        /// Returns the number of unique IP addresses
        /// </summary>
        /// <param name="requestList"></param>
        /// <returns></returns>
        public int UniqueIpCount(List<Request> requestList)
        {
            int uniqueIps = requestList.Select(l => l.IpAddress).Distinct().Count();
            return uniqueIps;
        }

        /// <summary>
        /// Returns the Top 3 most visited URLs
        /// </summary>
        /// <param name="requestList"></param>
        /// <returns></returns>
        public List<string> ListTopUrls(List<Request> requestList)
        {
            var mostVisitedSites = requestList.GroupBy(q => q.Url)
                        .OrderByDescending(gp => gp.Count())
                        .Take(3)
                        .Select(g => g.Key).ToList();
            return mostVisitedSites;
        }

        /// <summary>
        /// Returns the Top 3 most active IP addresses
        /// </summary>
        /// <param name="requestList"></param>
        /// <returns></returns>
        public List<string> ListTopIps(List<Request> requestList)
        {
            var mostActiveIps = requestList.GroupBy(q => q.IpAddress)
                                    .OrderByDescending(gp => gp.Count())
                                    .Take(3)
                                    .Select(g => g.Key).ToList();
            return mostActiveIps;

        }

    }
}
