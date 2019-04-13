using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Semestrovaya
{
    class Program
    {
        public static int Iterations;
        static void Main(string[] args)
        {
            for (var i = 0; i <= 96; i++)
            {
                string[] input = File.ReadAllLines($"C:\\rnd\\test{i}.txt", Encoding.Default);
                int[] arr = new int[input.Length];
                for (var j = 0; j < input.Length - 1; j++) arr[j] = int.Parse(input[j]);
                int n = arr.Length - 1;
                var t = DateTime.Now.Ticks;
                HeapSort(arr, n);
                Console.WriteLine($"Experiment№{i}, Kol-vo failov:{arr.Length}");
                Console.WriteLine(Math.Round((DateTime.Now.Ticks - t) / 10000000.0, 3));
                Console.WriteLine(Iterations);
                Iterations = 0;
                Console.WriteLine();
            }

            for (var i = 0; i <= 96; i++)
            {
                string[] input = File.ReadAllLines($"C:\\rnd\\test{i}.txt", Encoding.Default);
                LinkedList<int> list = new LinkedList<int>();
                for (var j = 0; j < input.Length - 1; j++) list.AddLast(int.Parse(input[j]));
                int n = list.Count;
                var t = DateTime.Now.Ticks;
                ForLinkedList.HeapSortForList(list, n);
                Console.WriteLine($"Experiment№{i}, Kol-vo failov:{list.Count}");
                Console.WriteLine(Math.Round((DateTime.Now.Ticks - t) / 10000000.0, 3));
                Console.WriteLine(ForLinkedList.IterationsForLists);
                ForLinkedList.IterationsForLists = 0;
                Console.WriteLine();
            }
            Console.Read();
        }

        static void HeapSort(int[] arr, int lenght)
        {
            for (int numOfNode = lenght / 2 - 1; numOfNode >= 0; numOfNode--) //преобразует все элементы в кучу
            { 
                
                Heapify(arr, lenght, numOfNode); //создает "максимальную кучу" (1)
            }

            for (int numOfNode = lenght - 1; numOfNode >= 0; numOfNode--) //O(n)
            { //меняет местами последний и первый элемент
                Iterations++;
                int temp = arr[0];
                arr[0] = arr[numOfNode];
                arr[numOfNode] = temp;
                Heapify(arr, numOfNode, 0);
            }
        }

        static void Heapify(int[] arr, int lenght, int numOfNode) //O(ln(n))
        {
            Iterations++;
            int indexOfLargest = numOfNode; 
            int left = 2 * numOfNode + 1; //индекс левой ветки ноды
            int right = 2 * numOfNode + 2; //индекс правой ветки ноды
            if (left < lenght && arr[left] > arr[indexOfLargest])
                indexOfLargest = left;
            if (right < lenght && arr[right] > arr[indexOfLargest])
                indexOfLargest = right;
            if (indexOfLargest != numOfNode)
            {
                int swap = arr[numOfNode];
                arr[numOfNode] = arr[indexOfLargest];
                arr[indexOfLargest] = swap;
                Heapify(arr, lenght, indexOfLargest);
            }
        }
    }
}
