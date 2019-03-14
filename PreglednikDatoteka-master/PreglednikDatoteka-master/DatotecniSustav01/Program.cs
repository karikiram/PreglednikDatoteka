using System;
using System.IO;

namespace DatotecniSustav01
{
    class Program
    {
        static void Main(string[] args)
        {

            string direktorij = @"C:\";
            DirectoryInfo dirInfo = new DirectoryInfo(direktorij);

            var datoteke = dirInfo.GetFiles();
            decimal velicina = 0;
            //string extension = Path.GetExtension(direktorij);
            //string filename = Path.GetFileName(direktorij);
            //string root = Path.GetPathRoot(direktorij);

            Console.WriteLine(" + ------------------+-------------+---------+------------------------------------------+");
            Console.WriteLine("| Veličina       B |          KB |      MB |      GB |   Nazivi datoteka                        |");
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            foreach (FileInfo d in datoteke)
            {
                string fullPath = Path.GetFullPath(d.FullName);
                velicina += d.Length;
                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3, 2} GB | {4,40} |",
                    d.Length,
                    d.Length / 1024,
                    d.Length / (1024 * 1024),
                    Math.Round((decimal)d.Length / (1024 * 1024 * 1024), 2),
                    fullPath);

            }
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3, 2} GB |                                          |",
                Math.Round(velicina, 0),
                Math.Round(velicina / (1024), 0),
                Math.Round(velicina / (1024 * 1024), 0),
                Math.Round(velicina / (1024 * 1024 * 1024), 2));
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");

            Console.SetCursorPosition(1, 3);
            Console.Write(">");
            int brojRedova = datoteke.Length + 6;

            int cekanjeTreperenje = 500;
            Console.CursorVisible = false;
            int pokazivacY = 3;
            while (true)
            {
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(" ");
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(">");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pritisnutaTipka = Console.ReadKey(true);
                    if (pritisnutaTipka.Key == ConsoleKey.DownArrow)
                    {
                        pokazivacY++;
                    }
                }
            }

            // Console.SetCursorPosition(0, brojRedova);
        } //Main
    }
}