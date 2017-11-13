using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDemo.common
{

    public class RedisDB
    {

        public string TestRedis()
        {
            string result = "";

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase db = redis.GetDatabase();
            string value = "test redis";
            db.StringSet("name", value);

            result += db.StringGet("name");


            ConfigurationOptions configurationOptions = new ConfigurationOptions()
            {
                EndPoints = { { "127.0.0.1", 6379 } },
                CommandMap = CommandMap.Create(new HashSet<string>()
　　　　　　{
　　　　　　　　"INFO",
　　　　　　　　"CONFIG",
　　　　　　　　"CLUSTER",
　　　　　　　　"PING",
　　　　　　　　"ECHO",
　　　　　　　　"CLIENT"
　　　　　　}, available: false),
                KeepAlive = 180,
                DefaultVersion = new Version(2, 8, 24)
            };
            IDatabase db1 = redis.GetDatabase();
            string value2 = "name2";
            db.StringSet("mykey2", value2);

         
            result += db.StringGet("mykey2");
            return result;

        }
    }
}