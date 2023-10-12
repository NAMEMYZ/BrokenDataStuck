using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RadixSort : ArrayListQueue
    {
        public RadixSort(int cap) : base(cap)
        {
        }

        public static void Sort(int[] arr)
        {
            int max = FindMax(arr);
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(arr, exp);
            }
        }

        private static void CountingSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < 10; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        private static int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        /*static void Main(string[] args)
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66, 1024 };

            Console.WriteLine("Original Array:");
            RadixSort.PrintArray(arr);

            RadixSort.Sort(arr);

            Console.WriteLine("Sorted Array:");
            RadixSort.PrintArray(arr);

            PriorityQueue x = new LinkedListPriorityQueue();
            x.enqueue(1);
            x.enqueue(2);
            x.enqueue(3);

            Console.WriteLine(x.dequeue());
            Console.WriteLine(x.dequeue());
        }*/
        /*static void Main(string[] args)
        {

           
            object[] x = new object[] { 2, 7, 1, 9, 10 ,20 ,99 , 108 ,1050 , 20 , 200};
            BinaryHeap.heapSort(x);
            for (int i = 0;i < x.Length;i++)
                Console.WriteLine(x[i]);

            //Console.WriteLine("Min element: " + minHeap1.peek()); 

            //while (!minHeap1.isEmpty())
            {
                //Console.WriteLine("Dequeued: " + minHeap1.dequeue());
            }

           // while (!minHeap2.isEmpty())
            {
               // Console.WriteLine("Dequeued: " + minHeap2.dequeue());
            }
        }*/
    }
}
