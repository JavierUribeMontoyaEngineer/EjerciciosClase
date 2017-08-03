using System;
using System.Collections.Generic;
using System.Linq;
namespace PruebasExtra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arregloEnteros = { 1, 2, 3, 5, 3, 2, 8, 9 };

            var sortedInt = from nums in arregloEnteros
                            orderby nums
                            select nums;
            ShowList(sortedInt);
            Console.ReadLine();
        }

        private static void ShowList(IEnumerable<int> nums)
        {
            var numsWithComma = String.Join(",",nums);
            Console.WriteLine(numsWithComma);
        }
    }
}