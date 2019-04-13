using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovaya
{
    public static class ForLinkedList
    {
        public static int IterationsForLists;
        public static void HeapSortForList(LinkedList<int> list, int lenght)
        {
            var arr = list.ToArray();
            for (int numOfNode = lenght / 2 - 1; numOfNode >= 0; numOfNode--) //преобразует все элементы в двоичную кучу
            {
                IterationsForLists++;
                HeapifyForList(arr, lenght, numOfNode); //создает "максимальную кучу" (1)
            }

            for (int numOfNode = lenght - 1; numOfNode >= 0; numOfNode--)
            { //ставим в корень дерева максимальный элемент
                IterationsForLists++;
                int temp = arr[0];
                arr[0] = arr[numOfNode];
                arr[numOfNode] = temp;
                HeapifyForList(arr, numOfNode, 0); 
            }
        }

        static void HeapifyForList(int[] arr, int lenght, int numOfNode)
        {
            IterationsForLists++;
            int largest = numOfNode;
            int left = 2 * numOfNode + 1;
            int right = 2 * numOfNode + 2;
            if (left < lenght && arr[left] > arr[largest])
                largest = left;
            if (right < lenght && arr[right] > arr[largest])
                largest = right;
            if (largest != numOfNode)
            {
                int swap = arr[numOfNode];
                arr[numOfNode] = arr[largest];
                arr[largest] = swap;
                HeapifyForList(arr, lenght, largest);
            }
        }
    }
}
