using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int iterations = rnd.Next(50, 100);
            for (int i = 0; i < iterations; i++)
            {
                List<string> list = new List<string>();
                int iter = rnd.Next(500, 10000);
                for(int j = 0; j < iter; j++)
                {
                    list.Add((j + 1 * rnd.Next()).ToString());
                }
                File.AppendAllLines($"C:\\rnd\\test{i}.txt", list);
            }
        }
    }
}
