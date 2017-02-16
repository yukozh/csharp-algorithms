using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var map = new Map();
            map[11] = "Hello World #11";
            map[6] = "Hello World #6";
            map[1] = "Hello World #1";
            map[3] = "Hello World #3";
            map[9] = "Hello World #9";
            map[13] = "Hello World #13";
            map[5] = "Hello World #5";
            map[14] = "Hello World #14";
            map[15] = "Hello World #15";
            map[2] = "Hello World #2";

            // Search
            Console.WriteLine("Key: 3, Value: " + map[3]);
            Console.Read();
        }
    }
}
