using System;
using System.Xml;

namespace XML01
{
    internal class Program
    {
        static void Test_SimpleParser()
        {
            XmlReader reader = XmlReader.Create("uebung3.xml", new XmlReaderSettings() { IgnoreWhitespace=true, IgnoreComments=true} );
            while(reader.Read())
            {
                Console.WriteLine("*******");
                Console.WriteLine("Name:   " + reader.Name);
                Console.WriteLine("Typ:    " + reader.NodeType);
                switch(reader.NodeType)
                {
                    case XmlNodeType.Element:
                        for(int i =0;i<reader.AttributeCount;i++)
                        {
                            reader.MoveToAttribute(i);
                            Console.WriteLine("Attribut:" + reader.Name + " = " + reader.Value);
                            // Console.WriteLine(reader.GetAttribute("einheit"));
                        }
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine("Value:" + reader.Value);
                        break;
                }
                Console.WriteLine("********");
            }
        }

        static void Main(string[] args)
        {
            Test_SimpleParser();
        }
    }
}
