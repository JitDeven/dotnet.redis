using dotnet.redis.SrcTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.redis
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTest.Run();

            Console.Read();
        }
    }
}
