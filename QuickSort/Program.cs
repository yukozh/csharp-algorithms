using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int> { 19, 8, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            a = QSort(a, 0, a.Count).ToList();
            foreach (var x in a)
                Console.Write(x + " ");
            Console.Read();
        }

        static void Print(IEnumerable<int> l, IEnumerable<int> c, IEnumerable<int> r)
        {
            foreach (var x in l)
                Console.Write(x + " ");
            Console.Write("【 ");
            foreach (var x in c)
                Console.Write(x + " ");
            Console.Write("】 ");
            foreach (var x in r)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        static IEnumerable<int> QSort(IEnumerable<int> array, int begin, int end)
        {
            if (begin >= end)
                return array;
            var arr_left = array.Take(begin);
            var arr_current = array.Skip(begin).Take(end - begin);
            var arr_right = array.Skip(end);
            Print(arr_left, arr_current, arr_right);
            var num = arr_current.First();
            var arr_lt = arr_current.Where(x => x < num);
            var arr_gt = arr_current.Where(x => x > num);
            var pos = begin + arr_lt.Count();
            arr_current = arr_lt.Concat(new[] { num }).Concat(arr_gt);
            var arr_return = arr_left.Concat(arr_current).Concat(arr_right);
            arr_return = QSort(arr_return, begin, pos);
            arr_return = QSort(arr_return, pos + 1, end);
            return arr_return;
        }
    }
}
