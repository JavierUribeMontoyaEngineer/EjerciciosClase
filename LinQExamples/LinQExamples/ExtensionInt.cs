using System;
using System.Collections.Generic;
using System.Text;

namespace LinQExamples
{
    public static class ExtensionInt
    {
        public static bool BetWeen(this int value, int from, int to)
        {
            return value >= from && value <= to;
        }
    }
}
