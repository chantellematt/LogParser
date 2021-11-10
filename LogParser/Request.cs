namespace LogParser
{
    public class Request
    {
        public string IpAddress;
        public string Url;
        public Request(string ipAddress, string url)
        {
            IpAddress = ipAddress;
            Url = url;
        }        
    }
}
