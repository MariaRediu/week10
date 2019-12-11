using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationGenerics
{
    class Program
    {
       internal static void Main(string[] args)
        {

            var floatGeneric = new GenericCalculator<float>();
        }
    }
    public class GenericCalculator<T>
    {
       public T Add(T a,T b)
        {
            return(dynamic) a + (dynamic)b;

        }
        public T Subs(T a,T b)
        {
            return (dynamic)a - (dynamic)b;
        }

    }
}
