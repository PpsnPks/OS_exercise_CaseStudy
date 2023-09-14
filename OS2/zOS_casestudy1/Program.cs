using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Problem01
    {
        private static readonly object _lock = new object();
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;
        static int G_index = 0;

        static int ReadData()
        {
            int returnData = 0;
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                Data_Global = (byte[])bf.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Read Failed:" + se.Message);
                returnData = 1;
            }
            finally
            {
                fs.Close();
            }

            return returnData;
        }

        static void ProcessBatch(int start, int end)
        {
            long localSum = 0;

            for (int j = start; j < end; j++)
            {
                long tempSum = 0;

                if (Data_Global[j] % 2 == 0)
                {
                    tempSum = -Data_Global[j];
                }
                else if (Data_Global[j] % 3 == 0)
                {
                    tempSum = Data_Global[j] * 2;
                }
                else if (Data_Global[j] % 5 == 0)
                {
                    tempSum = Data_Global[j] / 2;
                }
                else if (Data_Global[j] % 7 == 0)
                {
                    tempSum = Data_Global[j] / 3;
                }

                localSum += tempSum;
                Data_Global[j] = 0;
            }

            lock (_lock)
            {
                Sum_Global += localSum;
            }
        }

        static void sum()
        {
            if (Data_Global[G_index] % 2 == 0)
            {
                Sum_Global -= Data_Global[G_index];
            }
            else if (Data_Global[G_index] % 3 == 0)
            {
                Sum_Global += (Data_Global[G_index] * 2);
            }
            else if (Data_Global[G_index] % 5 == 0)
            {
                Sum_Global += (Data_Global[G_index] / 2);
            }
            else if (Data_Global[G_index] % 7 == 0)
            {
                Sum_Global += (Data_Global[G_index] / 3);
            }
            Data_Global[G_index] = 0;
            G_index++;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int y, i;
            int numThreads = Environment.ProcessorCount; // จำนวนเซลที่มีในเครื่อง

            /* Read data from file */
            Console.Write("Data read...");
            y = ReadData();
            if (y == 0)
            {
                Console.WriteLine("Complete.");
            }
            else
            {
                Console.WriteLine("Read Failed!");
                return;
            }

            /* Start */
            Console.Write("\n\nWorking...");

            Thread[] threads = new Thread[numThreads];
            int batchSize = 1000000000 / numThreads; // แบ่งงานเป็นส่วนๆ ให้แต่ละ thread ประมวลผล

            sw.Start();

            for (i = 0; i < numThreads; i++)
            {
                int start = i * batchSize;
                int end = (i + 1) * batchSize;
                if (i == numThreads - 1) end = 1000000000; // ปรับขอบเขตสุดท้ายให้เป็นสิ้นสุด

                threads[i] = new Thread(() => ProcessBatch(start, end));
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}

// using System;
// using System.Diagnostics;
// using System.IO;
// using System.Runtime.Serialization;
// using System.Runtime.Serialization.Formatters.Binary;
// using System.Threading;

// namespace Problem01
// {
//     class Program
//     {
//         static byte[] Data_Global = new byte[1000000000];
//         static long Sum_Global = 0;
//         static int G_index = 0;

//         static int ReadData()
//         {
//             int returnData = 0;
//             FileStream fs = new("Problem01.dat", FileMode.Open);
//             BinaryFormatter bf = new();

//             try 
//             {
//                 #pragma warning disable SYSLIB0011
//                 Data_Global = (byte[])bf.Deserialize(fs);
//                 #pragma warning restore SYSLIB0011

//             }
//             catch (SerializationException se)
//             {
//                 Console.WriteLine("Read Failed:" + se.Message);
//                 returnData = 1;
//             }
//             finally
//             {
//                 fs.Close();
//             }

//             return returnData;
//         }
//         static void sum()
//         {
//             if (Data_Global[G_index] % 2 == 0)
//             {
//                 Sum_Global -= Data_Global[G_index];
//             }
//             else if (Data_Global[G_index] % 3 == 0)
//             {
//                 Sum_Global += (Data_Global[G_index]*2);
//             }
//             else if (Data_Global[G_index] % 5 == 0)
//             {
//                 Sum_Global += (Data_Global[G_index] / 2);
//             }
//             else if (Data_Global[G_index] %7 == 0)
//             {
//                 Sum_Global += (Data_Global[G_index] / 3);
//             }
//             Data_Global[G_index] = 0;
//             G_index++;   
//         }
//         static void Main(string[] args)
//         {
//             Stopwatch sw = new Stopwatch();
//             int i, y;

//             /* Read data from file */
//             Console.Write("Data read...");
//             y = ReadData();
//             if (y == 0)
//             {
//                 Console.WriteLine("Complete.");
//             }
//             else
//             {
//                 Console.WriteLine("Read Failed!");
//             }

//             /* Start */
//             Console.Write("\n\nWorking...");
//             sw.Start();
//             for (i = 0; i < 1000000000; i++)
//                 sum();
//             sw.Stop();
//             Console.WriteLine("Done.");

//             /* Result */
//             Console.WriteLine("Summation result: {0}", Sum_Global);
//             Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
//         }
//     }
// }