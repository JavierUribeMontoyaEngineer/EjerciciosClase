using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqWithMethod2List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Diferencia usando linq method--");
            List<int> numbers, numbers2;
            CreateLists(out numbers, out numbers2);
            var difference = LinqWithMethod(numbers, numbers2);
            ShowList(difference);
            Console.WriteLine("--Diferencia usando linq query--");
            difference = LinqWithQuery(numbers, numbers2);
            ShowList(difference);
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

        private static void ShowList(IEnumerable<int> difference)
        {
            foreach (var number in difference)
            {
                Console.WriteLine(number);
            }
        }

    }
}