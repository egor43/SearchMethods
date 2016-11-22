using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSearchMethod
{
    class Program
    {
        public static bool LinearSearch(int[] args, int search_value)
        {
            Console.Write("Linear search: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool flag = false;
            foreach (var v in args)
            {
                if (search_value.CompareTo(v) == 0)
                {
                    flag = true;
                    break;
                }
            }
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1}", time.Seconds, time.TotalMilliseconds);
            if (flag)
            {
                Console.WriteLine("Value is found! Time: " + elapsed_time);
                return flag;
            }
            Console.WriteLine("Value is NOT found! Time: " + elapsed_time);
            return flag;
        }

        public static bool InterpolationSearch(int[] args, int search_value)
        {
            Console.Write("Interpolation search: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool flag = false;
            long mid;
            long low_border = 0;
            long high_border = args.Length - 1;
            while ((args[low_border] < search_value) && (args[high_border] > search_value))
            {
                mid = low_border + ((search_value - args[low_border]) * (high_border - low_border)) / (args[high_border] - args[low_border]);

                if (args[mid] < search_value) low_border = mid + 1;
                else if (args[mid] > search_value) high_border = mid - 1;
                else
                {
                    flag = true;
                    break;
                }
            }
            if ((args[low_border] == search_value) || (args[high_border] == search_value)) flag = true;
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1}", time.Seconds, time.TotalMilliseconds);
            if (flag)
            {
                Console.WriteLine("Value is found! Time: " + elapsed_time);
                return flag;
            }
            Console.WriteLine("Value is NOT found! Time: " + elapsed_time);
            return flag;
        }

        public static bool FibonnacheSearch(int[] args, int search_value)
        {
            Console.Write("Fibonnache search: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int[] Fib_Array = new int[45];
            Fib_Array[0] = 0;
            Fib_Array[1] = 1;
            Fib_Array[2] = 2;
            for (int i = 3; i < 45; i++)
            {
                Fib_Array[i] = Fib_Array[i - 1] + Fib_Array[i - 2];
            }
            bool flag = false;
            int[] Other_Array = args;
            bool iter_flag = true;
            if ((Other_Array[Other_Array.Length - 1] < search_value)|| (Other_Array[0] > search_value)) iter_flag = false;
            while (iter_flag)
            {
                int x = 0;
                int y = Other_Array.Length - 1;
                for (int i = 0; i < Fib_Array.Length - 1; i++)
                {
                    if ((Fib_Array[i] < Other_Array.Length-1) && (Other_Array[Fib_Array[i]] < search_value)) x = Fib_Array[i+1];
                    if ((Fib_Array[i+1] < Other_Array.Length-1) && (Other_Array[Fib_Array[i + 1]] > search_value))
                    {
                        y = Fib_Array[i+1];
                        break;
                    }
                }
                if (x==y)
                {
                    flag = true;
                    break;
                }
                List<int> arr = new List<int>();
                for (int j = x; j <= y; j++)
                {
                    arr.Add(Other_Array[j]);
                }
                Other_Array = arr.ToArray();
            }
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1}", time.Seconds, time.TotalMilliseconds);
            if (flag)
            {
                Console.WriteLine("Value is found! Time: " + elapsed_time);
                return flag;
            }
            Console.WriteLine("Value is NOT found! Time: " + elapsed_time);
            return flag;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Создание массива...");
            int[] Array = new int[134217727];
            for (int i = 0; i < Array.Length; i++) //134217727
            {
                Array[i] = rnd.Next(0, 9999999);
            }
            Console.WriteLine("Массив создан!");
            Console.WriteLine("Сортировка массива...");
            System.Array.Sort(Array);
            Console.WriteLine("Массив отсортирован");
            LinearSearch(Array, 400);
            InterpolationSearch(Array, 400);
            FibonnacheSearch(Array, 400);
            Console.ReadLine();
        }
    }
}
