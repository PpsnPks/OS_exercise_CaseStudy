using System;
using System.Threading;

// namespace Lab_OS_Concurrency
// {
//     class Program
//     {
//         static void TestThread1()
//         {
//             int i;
//             for (i = 0; i < 10; i++)
//                 Console.WriteLine("Thread# 1 i={0}",i);
//         }
//         static void TestThread2()
//         {
//             int i;
//             for (i = 0; i < 10; i++)
//                 Console.WriteLine("Thread# 2 i={0}",i);
//         }
//         static void Main(string[] args)
//         {
//             Thread th1 = new Thread(TestThread1);
//             Thread th2 = new Thread(TestThread2);
//             th1.Start();
//             th2.Start();
//         }
//     }
// }
namespace Lab_OS_Concurrency02
{
    class Program
    {
        static int resource =10000;
        static void TestThread1()
        {
            resource = 55555;
        }
        static void Main(string[] args)
        {
            Thread th1 = new Thread(TestThread1);
            th1.Start();
            //Thread.Sleep(10000);
            Console.WriteLine("resource={0}",resource);
        }
    }
}

// namespace Lab_OS_Concurrency01  Ex2
// {
//     class Program
//     {
//         static int resource =9999;
//         static void TestThread1()
//         {
//             Console.WriteLine("Thread# 1 i={0}",resource);
//         }
//         static void TestThread2()
//         {
//             Console.WriteLine("Thread# 2 i={0}",resource);
//         }
//         static void Main(string[] args)
//         {
//             Thread th1 = new Thread(TestThread1);
//             Thread th2 = new Thread(TestThread2);
//             th1.Start();
//             th2.Start();
//         }
//     }
// }
