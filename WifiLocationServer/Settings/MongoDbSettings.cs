using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WifiLocationServer.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string ConnectionString 
        {   get
            {
                return $"mongdb://{Host}:{Port}";
            }
        }
    }
}
