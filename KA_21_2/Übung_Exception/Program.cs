using System;
using System.Collections.Generic;

namespace Übung_Exception
{
    internal class Program
    {
        static void Test1()
        {
            List<string> binlist = new List<string>() { "11110001",
                "11A00",
                "2100",
                "110",
                "000111",
                "AABBC",
                "A01A0"
            };
            foreach (string bin in binlist)
            {
                Console.Write(bin + " => ");
                try
                {
                    Console.WriteLine(BinaryString.BinaryToDecimal2(bin));
                }
                catch (NoBinaryNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                   
                 //   Console.WriteLine("Pos" + ex.Position + " ist falsch");
                }
            }

        }

        static void Main(string[] args)
        {
            Test1();
        }
    }
}
