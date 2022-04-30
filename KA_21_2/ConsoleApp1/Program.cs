using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(@"c:\temp\test.log"));
            Debug.AutoFlush = true;
            Debug.WriteLine("HALLO WELT ....");
            // Debug.Flush();
            Console.ReadKey();
        }
    }
}
