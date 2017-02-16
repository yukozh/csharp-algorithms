using System;
using System.Collections.Generic;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {            
            // Arrange
            var map = new HashMap();
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
            map[222] = "Hello World #222";
            map[225] = "Hello World #225";
            map[123] = "Hello World #123";

            // Search
            Console.WriteLine("Key: 123, Value: " + map[123]);
            Console.Read();
        }
    }
}
