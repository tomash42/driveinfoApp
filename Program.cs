using System;
using System.IO;
using System.Threading;

namespace driveinfoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo cki;
            Console.WriteLine("1-Check your disk usage :");
            Console.WriteLine("9-Info");
            var number = Convert.ToSByte(Console.ReadLine());
            do
            {               
                switch (number)
                {
                    case 1:
                        driveTest();
                       
                        break;
                    case 9:
                        Console.WriteLine("tomash40@yandex.com");
                        Console.WriteLine("2022.09.04");
                        Console.WriteLine("V1.00.00");
                        break;
                    default:
                        Console.WriteLine("App is under construction...");
                        break;
                }
            Console.WriteLine("\n\nExit -> y :");
            cki = Console.ReadKey(true);
            } while (cki.KeyChar!=(char)'y');
           

          
        }

        private static void driveTest()
        {
            double percent = 100, kb = 1024, free, allspace,result,res,res1,res2;
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach (var item in di)
            {
                Console.WriteLine("\n Disk {0}\n",item.Name);

                //calculation of percentages
                free = item.AvailableFreeSpace;
                allspace = item.TotalSize;
                result = (free / allspace) * percent;
                //end calculation of percentages

                Console.WriteLine("You have a {0, 30} % of free disk",result);
                for (int i = 0; i <= result; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(".");
                    Thread.Sleep(40);
                    Console.ResetColor();
                    for (int j = i+1; j <= 100 & j >= result; j++)
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
                Console.WriteLine("Total size is : {0, 10} GB",res2);
                Console.ResetColor();
                Console.WriteLine("your disk is  : {0,10}",item.Name);
                Console.WriteLine("Disk type is  : {0,10}",item.DriveType);
                Console.WriteLine("Format is     : {0,10}\n",item.DriveFormat);
                
            }
            for (int i = 0; i <= Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }

    }
}
