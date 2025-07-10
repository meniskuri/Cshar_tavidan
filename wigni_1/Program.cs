using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wigni_1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //////////////////////////////////////
            /// მეთოდები
            void SayHello()
            {
                Console.WriteLine("//// metods vidzaxeb ////");
                Console.WriteLine("Hello");
            }

            void Sum(int k, int y)
            {
                int result = k + y;
                Console.WriteLine($"{k} + {y} = {result}");
            }

            //////////////////////////////////////
            Console.WriteLine("wignis mecadineoba daviwye");
            Console.WriteLine(3.2e3);   
            Console.WriteLine(3.2E3);

            Console.WriteLine("//////////////");
            float a = 3.14F;
            float b = 3.14f;
            Console.WriteLine(a);

            //////////////////////////////////////
            Console.WriteLine("////////////// xor operator");
            int x = 45; // Значение, которое надо зашифровать - в двоичной форме 101101
            int key = 102; //Пусть это будет ключ - в двоичной форме 1100110

            int encrypt = x ^ key; //Результатом будет число 1001011 или 75
            Console.WriteLine($"Зашифрованное число: {encrypt}");

            int decrypt = encrypt ^ key; // Результатом будет исходное число 45
            Console.WriteLine($"Расшифрованное число: {decrypt}");

            //////////////////////////////////////
            /// ბევრ განზომილებიანი მასივები
            Console.WriteLine("////////////// xor operator");
            int[,] nums2 = { { 0, 1, 2 }, { 3, 4, 5 } };

            foreach (int n in nums2)
            {
                Console.WriteLine("nums2 = " + n);
            }
            Console.WriteLine("sigrdze nums2 masivis :" + nums2.Length);


            //
            int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 } };

            int rows = numbers.GetUpperBound(0) + 1;    // количество строк
            int columns = numbers.Length / rows;        // количество столбцов
                                                        // или так
                                                        // int columns = numbers.GetUpperBound(1) + 1
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{numbers[i, j]} \t");
                }
                Console.WriteLine();
            }

            //
            SayHello();
            Sum(1, 2);
        }
    }
}
