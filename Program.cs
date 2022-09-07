using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace driveinfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.WriteLine("1-Check your disk usage :");
            Console.WriteLine("2-Get more disk space c :");
            Console.WriteLine("9-Info");
            var number = Convert.ToSByte(Console.ReadLine());
            do
            {
                switch (number)
                {
                    case 1:
                        driveTest();

                        break;
                    case 2:
                        statsFileToDelete();
                        break;
                    case 9:
                        Console.WriteLine("tomash40@yandex.com");
                        Console.WriteLine("Start 2022.09.04");
                        Console.WriteLine("V1.04.05");
                        break;
                    default:
                        Console.WriteLine("App is under construction...");
                        break;
                }
                Console.WriteLine("\n\nExit -> y :");
                cki = Console.ReadKey(true);
            } while (cki.KeyChar != (char)'y');
        }

        private static void driveTest()
        {
            double percent = 100, kb = 1024, free, allspace, result, res, res1, res2;
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach (var item in di)
            {
                if (item.IsReady == true)
                {
                    Console.WriteLine("Disk {0, 3} is Ready",item.Name);
                }
                else
                {
                    Console.WriteLine("Disk {0, 3} is not ready :",item.Name);
                    break;
                }
                //calculation of percentages
                free = item.AvailableFreeSpace;
                allspace = item.TotalSize;
                result = (free / allspace) * percent;
                //end calculation of percentages
                Console.WriteLine("You have a {0, 30} % of free disk", result);
                for (int i = 0; i <= result; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(".");
                    Thread.Sleep(40);
                    Console.ResetColor();
                    for (int j = i + 1; j <= 100 & j >= result; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|");
                        Console.ResetColor();
                    }


                }

                Console.Write("\n\n");
            }
            for (int i = 0; i <= Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            foreach (var item in di)
            {
                //converter to gb
                res = item.TotalSize / kb;
                res1 = res / kb;
                res2 = res1 / kb;
                //converter to gb
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Total size is : {0, 10} GB", res2);
                Console.ResetColor();
                Console.WriteLine("your disk is  : {0,10}", item.Name);
                Console.WriteLine("Disk type is  : {0,10}", item.DriveType);
                Console.WriteLine("Format is     : {0,10}\n", item.DriveFormat);

            }
            for (int i = 0; i <= Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }
        private static void statsFileToDelete()
        {
            int countDir, countFiles;
            string tmpPath;
            tmpPath = Path.GetTempPath();

            //info
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TEMP Folder Statistics: \n Delete the contents and get more space on the C drive  ");
            Console.ResetColor();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            //end info

            //Displey the path
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Path for your TEMP is : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(tmpPath);
            Console.ResetColor();
            //End Displey the path
            try
            {

                List<string> direcTmp = new List<string>(Directory.EnumerateDirectories(tmpPath, "", SearchOption.AllDirectories));
                List<string> fIlesTmp = new List<string>(Directory.EnumerateFiles(tmpPath, "", SearchOption.AllDirectories));
                countDir = direcTmp.Count;
                countFiles = fIlesTmp.Count;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\n\nTotal Directory  :");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(countDir);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nTotal Files      :");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(countFiles);
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("is not available : {0}",e.Message);
                Console.ResetColor();
            }
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }
    }
}
