using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new LimitedList<string>(capacity: 3);

            Console.WriteLine(list.Add("first"));
            Console.WriteLine(list.Add("second"));
            Console.WriteLine(list.Add("third"));
            Console.WriteLine(list.Add("fourth"));

            list.Remove("first");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            foreach (var number in EvenNumbers())
            {
                Console.WriteLine(number);
                if (number > 100) break;
            }

            Console.ReadKey();
        }

        public static IEnumerable<int> Four()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }

        public static IEnumerable<int> EvenNumbers()
        {
            int i = 1;
            while (true)
            {
                yield return i;
                i += 2;
            }
        }
    }
}