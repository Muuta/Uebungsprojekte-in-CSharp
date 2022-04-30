using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DatenGenerator
{
    // ERWEITERUNGS-METHODE

    public static class Helper
    {
        public static string ToXml<T>(this T obj)
        {
            // Reflection
            Type t = typeof(T);
            string ret = $"<{t.Name}";
            // Iteration über Eigenschaften von T
            foreach (PropertyInfo pi in t.GetRuntimeProperties())
            {
                // Vorname        =  "Hans"
                if (pi.PropertyType == typeof(DateTime))
                {
                    //    ret += $" {pi.Name}=\"{((DateTime)pi.GetValue(obj)).ToString("yyyy-MM-dd")}\"";
                    ret += $" {pi.Name}=\"{pi.GetValue(obj):yyyy-MM-dd}\"";
                }
                else
                {
                    ret += $" {pi.Name}=\"{pi.GetValue(obj)}\"";
                }
            }
            ret += "/>";
            return ret;
        }
        /// <summary>
        /// DAS IST EINE ERWEITERUNGSMETHODE
        /// Write gibt einen Auflistung auf der Konsole aus
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        /// <param name="header"></param>
        public static void Write<T>(this IEnumerable<T> l, string header = "")
        {
            Console.WriteLine("****" + header + "****");
            foreach (var elem in l)
            {
                if(elem.GetType() == typeof(string) ||
                    elem.GetType().IsValueType)
                    Console.WriteLine(elem);
                else
                    Console.WriteLine(ToXml(elem));
            }
            Console.WriteLine("*************");
        }


    }
}
