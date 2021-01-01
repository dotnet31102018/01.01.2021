using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        private static bool Save(string host, string key, string value)
        {
            bool isSuccess = false;
            using (RedisClient redisClient = new RedisClient(host))
            {
                if (redisClient.Get<string>(key) == null)
                {
                    isSuccess = redisClient.Set(key, value);
                }
            }
            return isSuccess;
        }
        private static string Get(string host, string key)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                return redisClient.Get<string>(key);
            }
        }

        static void Main(string[] args)
        {
            string host = "localhost";
            string key = "secret_code";
            //bool success = Save(host, key, "88-1323-453-22345");
            //Console.WriteLine("Saved!");

            string code = Get(host, "secret_code");
            Console.WriteLine($"Redis returned {key}: {code}");
            Console.WriteLine();
        }
    }
}
