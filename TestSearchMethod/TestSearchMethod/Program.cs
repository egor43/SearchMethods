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
            string elapsed_time = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
            if (flag)
            {
                Console.WriteLine("Value is found! Time: "+elapsed_time);
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
            Array.Sort(args);
            bool flag = false;
            int mid;
            int low_border = 0;
            int high_border = args.Length - 1;
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
            string elapsed_time = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
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
                Array[i]=rnd.Next(0, 9999999);
            }
            Console.WriteLine("Массив создан!");

            LinearSearch(Array, 9999999);
            InterpolationSearch(Array, 9999999);
            Console.ReadLine();
        }
    }
}
