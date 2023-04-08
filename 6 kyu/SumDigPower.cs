using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CodeWarsTask._6_kyu {
    public class SumDigPower {
        public static long[] SumDigPow(long a, long b) {
            //smartly:
            /* Enumerable.Range((int) a, (int) (b - a)) - диапазон от а до б-а, без костылей */
            return new long[b-a].Select((_, i) => IsEureka(a+i) == true ? a+i : 0 ).Where(x => x != 0).ToArray();
        }

        public static Boolean IsEureka(long n) {
            return n.ToString().Select((c, q) => Math.Pow(long.Parse(c.ToString()), q+1)).Sum() == n;
        }
    }
}
