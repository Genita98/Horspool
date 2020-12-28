using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorspoolAlgo
{
    class Program
    {
        static void Main(string[] args)
        {

            int position;
            Horspool horsepool = new Horspool();
                Console.WriteLine("Jepni tekstin:");
                string source = Console.ReadLine();
                Console.WriteLine("Jepni pattern-in:");
                string pattern = Console.ReadLine();

                horsepool.shiftTable(pattern);
                position = horsepool.horspool(source, pattern);
                if (position == -1)
                    Console.WriteLine("Pattern nuk u gjet!");
                else
                    Console.WriteLine("Patter-i u gjet ne pozicionin: " + position);
            Console.ReadLine();
            
        }

        class Horspool
        {
            public static int size = 200;
            public static int[] table = new int[size];

            //tabela ku e ben shift patternin
            public void shiftTable(string pattern)
            {
                char[] patternArray = pattern.ToCharArray();
                int m = pattern.Length;

                for (int i = 0; i < size; i++)
                    table[i] = m;

                for (int j = 0; j < m - 1; j++)
                    table[patternArray[j]] = m - 1 - j;
            }

            //metoda per algoritmin e horspool-it
            public int horspool(string source, string pattern)
            {
                int k;
                char[] sourceArray = source.ToCharArray();
                char[] patternArray = pattern.ToCharArray();
                int m = pattern.Length;

                int i = m - 1;

                while (i < source.Length)
                {
                    k = 0;
                    while ((k < m) && (patternArray[m - 1 - k] == sourceArray[i - k]))
                        k++;
                    if (k == m)
                        return i - m + 1;
                    else
                        i += table[sourceArray[i]];
                }
                return -1;
            }
        }
    }
}
