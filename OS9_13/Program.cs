using  System;
using System.Diagnostics;
using System.Threading;

namespace cv_lab_05
{
    class Program
    {
        private static string x = "";
        private static int exitflag = 0;
        private static int updateFlag = 0;

        static void ThReadX()
        {
            while(exitflag == 0)
            {
                if (x != "exit" && updateFlag == 1)
                {
                    Console.WriteLine("X = {0}",x);
                    updateFlag = 0;
                }
            }
        }

        static void ThWriteX()
        {
            string xx;
            while(exitflag == 0)
            {
                if(updateFlag == 0)
                {
                    Console.Write("Input: ");
                    xx = Console.ReadLine();
                    if (xx == "exit")
                        exitflag = 1;
                    else
                    {
                        x = xx;
                        updateFlag = 1;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Thread A = new Thread(ThReadX);
            Thread B = new Thread(ThWriteX);

            A.Start();
            B.Start();
        }
    }
}

/*namespace cv_lab_05
{
    class Program
    {
        private static string x = "";
        private static int exitflag = 0;
        private static int updateFlag = 0;
        private static object _Lock = new object();

        static void ThReadX(object i)
        {
                while(exitflag == 0)
                {
                    lock(_Lock)
                    {
                        if (x != "exit" && updateFlag == 1)
                        {
                            Console.WriteLine("***Thread {0} : x = {1}***",i,x);
                            updateFlag = 0;
                        }
                    }
                }
                Console.WriteLine("---Thread {0} : exit---",i);
        }

        static void ThWriteX()
        {
            string xx;
            while(exitflag == 0)
            {
                if(updateFlag == 0)
                {
                    Console.Write("Input: ");
                    xx = Console.ReadLine();
                    if (xx == "exit")
                        exitflag = 1;
                    x = xx;
                    //Console.WriteLine("Before updateF 1");
                    if (x == xx)
                    {
                        //Console.WriteLine("updateF 1");
                        updateFlag = 1;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Thread A = new Thread(ThWriteX);
            Thread B = new Thread(ThReadX);
            Thread C = new Thread(ThReadX);
            Thread D = new Thread(ThReadX);

            A.Start();
            B.Start(1);
            C.Start(2);
            D.Start(3);
        }
    }
}*/

/*namespace OS_Sync_Ex_03
{
    class Program
    {
        private static int sum = 0;
        private static object _Lock = new object();

        static void plus()
        {
            int i;
            lock (_Lock)
            {
                for (i = 0; i < 1000001;i++)
                    sum += i;
            }
        }

        static void minus()
        {
            int i;
            lock (_Lock)
            {
                for (i = 0; i < 1000000;i++)
                    sum -= i;
            }
        }

        static void Main(string[] args)
        {
            Thread P = new Thread(new ThreadStart(plus));
            Thread M = new Thread(new ThreadStart(minus));

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start...");
            sw.Start();

            P.Start();
            M.Start();

            P.Join();
            M.Join();

            sw.Stop();
            Console.WriteLine("sum = {0}",sum);
            Console.WriteLine("Time used: "+ sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}*/

/*namespace OS_Sync_Ex_02
{
    class Program
    {
        private static int sum = 0;
        private static object _Lock = new object();

        static void plus()
        {
            int i;
            for (i = 0; i < 1000001;i++)
                lock (_Lock)
                {
                    sum += i;
                }
        }

        static void minus()
        {
            int i;
            for (i = 0; i < 1000000; i++)
                lock (_Lock)
                {
                    sum -= i;
                }
        }

        static void Main(string[] args)
        {
            Thread P = new Thread(new ThreadStart(plus));
            Thread M = new Thread(new ThreadStart(minus));

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start...");
            sw.Start();

            P.Start();
            M.Start();

            P.Join();
            M.Join();

            sw.Stop();
            Console.WriteLine("sum = {0}",sum);
            Console.WriteLine("Time used: "+ sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}*/

/*namespace OS_Sync_Ex_01
{
    class Program
    {
        private static int sum = 0;

        static void plus()
        {
            int i;
            for (i = 0; i < 1000001;i++)
                sum += i;
        }

        static void minus()
        {
            int i;
            for (i = 0; i < 1000000; i++)
                sum -= i;
        }

        static void Main(string[] args)
        {
            Thread P = new Thread(new ThreadStart(plus));
            Thread M = new Thread(new ThreadStart(minus));

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start...");
            sw.Start();

            P.Start();
            M.Start();

            P.Join();
            M.Join();

            sw.Stop();
            Console.WriteLine("sum = {0}",sum);
            Console.WriteLine("Time used: "+ sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}*/

/*namespace OS_Sync_Ex_00
{
    class Program
    {
        private static int sum = 0;

        static void plus()
        {
            int i;
            for (i = 0; i < 1000001;i++)
                sum += i;
        }

        static void minus()
        {
            int i;
            for (i = 0; i < 1000000; i++)
                sum -= i;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start...");
            sw.Start();
            plus();
            minus();
            sw.Stop();
            Console.WriteLine("sum = {0}",sum);
            Console.WriteLine("Time used: "+ sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}*/