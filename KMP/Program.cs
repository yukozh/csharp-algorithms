// http://www.ruanyifeng.com/blog/2013/05/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm.html

using System;
using System.Linq;

namespace KMP
{
    class Program
    {
        // 求模式串前后缀最长公共元素长度
        static void BuildTable(string sub, out int[] table)
        {
            table = new int[sub.Length];

            if (string.IsNullOrWhiteSpace(sub))
            {
                return;
            }

            for (int i = 1; i < sub.Length; ++i)
            {
                // 取前缀
                var prefix = Enumerable.Range(1, i - 1).Select(x => sub.Substring(0, x));

                // 取后缀
                var postfix = Enumerable.Range(1, i - 1).Select(x => sub.Substring(i - x, x));

                // 取交集中最长元素长度
                var longest = prefix.Intersect(postfix).OrderByDescending(x => x.Length).FirstOrDefault();

                // 构造部分匹配表
                table[i - 1] = longest?.Length ?? 0;
            }
        }

        static int KmpSearch(string src, string sub)
        {
            var ret = 0;
            BuildTable(sub, out var table);

            // 模式串与原串比对
            for (var i = 0; i < src.Length - sub.Length + 1; i++)
            {
                Console.WriteLine(src.Substring(i));

                if (src[i] != sub[0])
                {
                    continue;
                }

                var failed = false;
                for (var j = 0; j < sub.Length; j++)
                {
                    if (src[i + j] != sub[j])
                    {
                        // 计算移动数量
                        var move = j - table[j - 1];
                        i += move - 1;
                        failed = true;
                        break;
                    }
                }

                if (!failed)
                {
                    // 完全匹配返回值加1
                    ++ret;
                }
            }

            return ret;
        }

        static void Main()
        {
            Console.WriteLine(KmpSearch("BBC ABCDAB ABCDABCDABDE", "ABCDABD"));
            Console.Read();
        }
    }
}
