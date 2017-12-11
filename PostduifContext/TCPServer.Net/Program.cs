using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPServer.standard;

namespace TCPServer.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            Console.WriteLine("waiting");
            Console.ReadKey();
        }
    }
}
