using System;
using TCPClient.standard;

namespace TCPClient.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            Console.WriteLine("waiting");
            Console.ReadKey();
        }
    }
}
