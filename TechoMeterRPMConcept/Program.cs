using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks.Sources;

namespace TerminalAppTest
{
    internal class Program
    {

        public static int score;
        public static int RPM_;
        public static readonly object padlock = new object();

        static void Main(string[] args)
        {

            Program program = new Program();
            bool Booter = true;

            Task.Run(() => Dashboard());
            Task.Run(() => RPM());
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                    if (keyinfo.Key == ConsoleKey.Q)
                    {
                        lock (padlock)
                        {
                            if (score >= 132)
                            {
                                score = 132;
                            }
                            else
                            {
                                score++;
                            }
                            //Console.WriteLine(score.ToString());
                        }

                    }

                }
                else
                {
                    if (score - 5 <= 0)
                    {
                        score = 0;
                    }
                    else if (score >= 2)
                    {
                        score -= 9;
                        //Console.WriteLine(score);
                    }
                    //lock (padlock)
                    //{
                    //    score--;
                    //}
                    Thread.Sleep(1000);
                }

            }
        }


        private static void Display(string RPM,int x = 25, int y = 15)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(RPM);
        }

        private static void Dashboard()
        {
            while (true)
            {


                Console.SetCursorPosition(30, 5);
                Console.Write($"RPM : {RPM_.ToString()}K");

                Console.SetCursorPosition(0,0);
                Console.WriteLine("        -----------------------------------------------------------------------------------------");
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine("        |                                                                                       |");
                }
                Console.WriteLine("        -----------------------------------------------------------------------------------------");

                

            }
        } 

        private static void RPM()
        {
            while (true)
            {
                lock (padlock)
                {
                    if (score <= 10)
                    {
                        RPM_ = 0;
                    }
                    if (score > 10 && score <= 20)
                    {
                        RPM_ = 3;
                    }
                    if (score > 24 && score <= 70)
                    {
                        RPM_ = 6;
                    }
                    if (score > 70 && score <= 100)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        RPM_ = 8;
                    }
                    if (score > 100 && score <= 132)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        RPM_ = 9;
                    }
                }
            }
        }
    }
}