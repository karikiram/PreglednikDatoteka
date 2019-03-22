using System;
using System.Diagnostics;
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

            // detaljan ispis veličine fajlova u datoteci

            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            Console.WriteLine("| Veličina       B |          KB |      MB |      GB |          TB |   Nazivi datoteka                        |");
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            foreach (FileInfo d in datoteke)
            {
                string directoryFullPath = Path.GetFullPath(d.FullName);
                velicina += d.Length;
                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3, 2} GB | {4, 1} TB | {5,40} |",
                    d.Length,
                    d.Length / 1024,
                    d.Length / (1024 * 1024),
                    Math.Round((decimal)d.Length / (1024 * 1024 * 1024), 2),
                    Math.Round((decimal)d.Length / (1024 * 1024 * 1024) / 1024, 6),
                    directoryFullPath);

            }
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3, 2} GB | {4, 1} TB |                                          |",
                Math.Round(velicina, 0),
                Math.Round(velicina / (1024), 0),
                Math.Round(velicina / (1024 * 1024), 0),
                Math.Round(velicina / (1024 * 1024 * 1024), 2),
                Math.Round(velicina / (1024 * 1024 * 1024) / 1024, 6)); 
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
                        Console.SetCursorPosition(1, pokazivacY);
                        Console.Write(" ");
                        pokazivacY++;
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pritisnutaTipka3 = Console.ReadKey(true);
                        if (pritisnutaTipka.Key == ConsoleKey.UpArrow)
                        {
                            Console.SetCursorPosition(1, pokazivacY);
                            Console.Write(" ");
                            pokazivacY--;
                        }
                    }
                    if (Console.KeyAvailable)
                    {

                            // metoda za otvaranje datoteke u kojoj se nalaze fajlovi

                            ConsoleKeyInfo pritisnutaTipka2 = Console.ReadKey(true);
                            if (pritisnutaTipka.Key == ConsoleKey.D)
                            {
                                //if (!File.Exists(direktorij))
                                //{
                                //    return;
                                //}
                                Process.Start("explorer.exe", direktorij);
                            }
                    
                    }
            }
        }

            // Console.SetCursorPosition(0, brojRedova);
        } //Main
    }
}