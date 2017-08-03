using System;
using System.Collections.Generic;
using System.Linq;
namespace Linq2List
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("--Diferencia de 2 listas usando linq method--");
            List<int> numbers, numbers2;
            CreateLists(out numbers, out numbers2);
            var difference = LinqWithMethod(numbers, numbers2);
            Console.WriteLine(String.Join(",",difference));
            Console.WriteLine("--Diferencia de 2 listas usando linq query--");
            difference = LinqWithQuery(numbers, numbers2);
            Console.WriteLine(String.Join(",", difference));
            Console.ReadLine();
        }

        private static void CreateLists(out List<int> numbers, out List<int> numbers2)
        {
            numbers = new List<int>()
            {
                1,2,3
            };
            numbers2 = new List<int>()
            {
                1,2
            };
        }

        private static IEnumerable<int> LinqWithMethod(List<int> numbers, List<int> numbers2)
        {
            return numbers.Where(n => !numbers2.Contains(n));
        }

        private static IEnumerable<int> LinqWithQuery(List<int> numbers, List<int> numbers2)
        {
            var result = from n in numbers
                         join r in numbers2 
                         on n equals r into grp
                         where !grp.Any()
                         select n;
                       
            return result;
        }
    }
}