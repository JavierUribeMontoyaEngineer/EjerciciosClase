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
            Console.WriteLine("Caso extender int con funcion between");
            Console.WriteLine(a.BetWeen(9, 10));
            Console.WriteLine("Caso con funcion Predicate");
            var bigNumbersPredicate = numbers.Where(n => n > 1);
            foreach (var number in bigNumbersPredicate)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Caso con linq");
            var bigNumbersLinq = numbers.Where(n => n > 1);
            foreach (var number in bigNumbersLinq)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();

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