using System.Threading.Tasks.Sources;

namespace TerminalAppTest
{
    internal class Program
    {

        public static int score;
        public static readonly object padlock = new object();

        static void Main(string[] args)
        {

            Program program = new Program();
            bool Booter = true;


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
                            Console.WriteLine(score.ToString());
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
        private static void RPM()
        {
            while (true)
            {
                lock (padlock)
                {
                    if (score <= 10)
                    {
                        Console.WriteLine("RPM : 0k");
                    }
                    if (score > 10 && score <= 20)
                    {
                        Console.WriteLine("RPM : 3k");
                    }
                    if (score > 24 && score <= 70)
                    {
                        Console.WriteLine("RPM : 6k");
                    }
                    if (score > 70 && score <= 100)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("RPM : 8k");
                    }
                    if (score > 100 && score <= 132)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("RPM : 9k");
                    }
                }
            }
        }
    }
}