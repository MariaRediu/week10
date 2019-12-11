using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaGenerics
{
   static class Program
    {
        private static void Main(string[] args)
        {
                var stringList = new GenericList<string>(3);

                //Auto - grow functionality
                stringList.Add("1");
                stringList.Add("2");
                stringList.Add("3");
                Console.WriteLine("\n" + stringList);
                Console.ReadLine();


            // Insert, RemoveAt
                stringList.Clear();
                stringList.Insert(0, "4");
                stringList.Insert(0, "3");
                stringList.Insert(0, "2");
                stringList.Insert(0, "1");
                Console.WriteLine("\n" + stringList);
                stringList.RemoveAt(0);

            // Contains, IndexOf
                Console.WriteLine("\nContain element 2: {0}", stringList.Contains("2"));
                Console.WriteLine("Index of element 3: {0}", stringList.IndexOf("3"));

                // Max, Min
                Console.WriteLine("\nMin: {0}", stringList.Min());
                Console.WriteLine("Max: {0}", stringList.Max());

                Console.WriteLine("\n" + stringList);
                Console.ReadLine();
        }
        
    }

}
