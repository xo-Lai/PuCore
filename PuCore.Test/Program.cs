using PuCore.Utility.Config;
using System;

namespace PuCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppConfig.RedisConnection);
            Console.Read();
        }
    }
}
