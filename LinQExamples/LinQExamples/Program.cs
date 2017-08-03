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
            var bigNumbers = numbers.Where(Predicate);
            bigNumbers = numbers.Where(n => n > 1);
            var a = 10;
            a.BetWeen(2, 20);
            

        }

        static bool Predicate(int value)
        {
            return value > 1;
        }
    }
}