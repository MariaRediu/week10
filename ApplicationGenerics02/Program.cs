using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGenerics02
{
    class Program
    {
        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Publisher Publisher { get; set; }

            public static bool operator >(Book b1,Book b2)
            {
                if(b1.Id>b2.Id)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }

        public class Publisher:IComparable<Publisher>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int CompareTo(Publisher other)
            {
                if (this.Id < other.Id)
                {
                    return -1;

                }
                if(this.Id > other.Id)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        internal class BookComparator
        {
            public Book Max(Book a,Book b)
            {
                if (a > b)
                {
                    return a;
                }
                else
                {
                    return b;
                }

            }
        }

        public class Comparator<T> where T: IComparable<T>
        {
            public T Max(T a, T b)
            {
                if (a.CompareTo(b)>0)
                {
                    return a;
                }
                else
                {
                    return b;
                }
        }
        internal static void Main(string[] args)
        {


        }

       
    }
}
