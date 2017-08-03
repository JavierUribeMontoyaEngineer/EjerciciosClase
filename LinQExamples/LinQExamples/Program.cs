using System;
using System.Collections.Generic;
using System.Linq;
namespace LinQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>()
            {
                1,2,3
            };
            var a = 10;
            var bigNumbers = numbers.Where(n => n > 1);
            // Console.WriteLine(bigNumbers);

            foreach (var item in numbers)
            {
                if (item == 2)
                    break;
            }
        }

        static bool Predicate(int value)
        {
            return value > 1;
        }

        static IEnumerable<int> Iterator()
        {
            for (var i = 0; i < 100; i++)
            {
                yield return i;
            }
        }
    }
}