using System;
using System.IO;

namespace LogFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "input.txt";
            string outPut = "output.txt";
            LogClass log = new LogClass();
            using (StreamReader sr = new StreamReader(input))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    log.AddLog(line);
                }
            }
            bool wantMore = true;

            while (wantMore)
            {
                Console.WriteLine("Give the part to filter for");
                string filter = Console.ReadLine();
                log.FilterForLogNotContains(filter);

                Console.WriteLine("Want more? (yes/no)");
                string answer = Console.ReadLine();
                File.Delete(outPut);
                if (answer == "no")
                {
                    using (StreamWriter sw = File.CreateText(outPut))
                    {
                        foreach (string item in log.FilteredLines)
                        {
                            sw.WriteLine(item);
                        }
                    }

                    wantMore = false;
                }
            }
            Console.WriteLine($"Written to {outPut}");
            Console.ReadLine();
        }
    }
}
