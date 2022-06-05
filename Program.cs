using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ыф
{
    internal class Program
    {
        static List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static void Main(string[] args)
        {
            Console.WriteLine("Какой поток запустить?\n");

            Thread myThread1 = new Thread(EvenAndOdd);

            myThread1.Name = "Вывод четный и нечетных чисел List";

            Console.WriteLine($"Имя потока - {myThread1.Name}, \nId потока - {myThread1.ManagedThreadId}, \nЗапущен ли поток - {myThread1.IsAlive}, \nПриоритет потока: {myThread1.Priority}, \nСтатус потока: {myThread1.ThreadState}\n");

            Thread myThread2 = new Thread(AllList);

            myThread2.Name = "Деление списка";

            Console.WriteLine($"Имя потока - {myThread2.Name}, \nId потока - {myThread2.ManagedThreadId}, \nЗапущен ли поток - {myThread1.IsAlive}, \nПриоритет потока: {myThread1.Priority}, \nСтатус потока: {myThread2.ThreadState}\n");

            Console.WriteLine("Если хотите запустить оба, напишите - оба\n");
            string operation = Console.ReadLine();

            if (operation == "3")
            {
                myThread1.Start();
            }
            else if (operation == "4")
            {
                myThread2.Start();
            }
            else if (operation == "оба")
            {
                Thread.Yield();
                myThread1.Start();
                Thread.Yield();
                myThread2.Start();
            }

        }

        public static void EvenAndOdd()
        {
            foreach (int i in list)
            {
                if (i % 2 == 0)
                {
                    Console.Write("Четные числа  - ");
                    Console.WriteLine(i + " ");
                }

                else
                {
                    Console.Write("Нечетные числа  - ");
                    Console.WriteLine(i);
                }
                Thread.Sleep(230);
            }
        }

        static void AllList()
        {
            int i = 0;
            foreach (double s in list)
            {
                i++;
                Console.WriteLine($"Index {i} - {s / 2}");
                Thread.Sleep(230);
            }
        }
    }
}
