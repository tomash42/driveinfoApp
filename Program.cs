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
            Console.WriteLine("3-List directory and files :");
            Console.WriteLine("4-BackUp files :");
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
                    case 3:
                        listDirAndFile();
                        break;
                    case 4:
                        backUp();
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
            int countDir, countFiles, sum=0, sum1=0;
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
            //get Time create Directory
            //calculating the old age of a file
            IEnumerable<string> ie1 = Directory.GetDirectories(tmpPath,"",SearchOption.AllDirectories);
            foreach (var item in ie1)
            {
                DateTime getTimeD = Directory.GetCreationTime(item);
               
                if (DateTime.Now.Subtract(getTimeD).TotalDays <= 31)
                {
                    sum++;
                }
                else if (DateTime.Now.Subtract(getTimeD).TotalDays >= 32 & DateTime.Now.Subtract(getTimeD).TotalDays <= 182)
                {
                    sum1++;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Files not older than 31 days : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sum);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Old files up to half a year  : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sum1);
            Console.ResetColor();

            // end calculating the old age of a file
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }

        private static void listDirAndFile()
        {

            DriveInfo[] drinfo = DriveInfo.GetDrives();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("Choose one of the available drives.");
            foreach (var item in drinfo)
            {
                
                Console.Write("Your disk :");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}", item.Name);
                Console.ResetColor();
            }
            
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            //Get data from user
            Console.WriteLine("Enter drive letter (example c) :");
            string diskName = Console.ReadLine();
            Console.WriteLine("Enter path  (example media or leave blank) :");
            string pathName = Console.ReadLine();
            //END Get data from user
            //Construction of path
            string path = $@"{diskName}:\{pathName}";
            string path2 = Directory.GetDirectoryRoot(path);
            try
            {
                if (Directory.Exists(path))
                {
                    string[] list1 = Directory.GetFileSystemEntries(path, "", SearchOption.AllDirectories);
                   
                    for (int i = 0; i < list1.Length; i++)
                    {
                        DateTime dt = Directory.GetCreationTime(list1[i]);
                        Console.WriteLine(list1[i]);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("Created :");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0} ", dt);
                        Console.ResetColor(); ;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Path -> {0} <- not exist.\n This is your all list ",path);
                    Console.ResetColor();

                    foreach (var item in drinfo)
                    {
                        string[] list2 = Directory.GetDirectories(item.Name);
                        for (int i = 0; i < list2.Length; i++)
                        {
                            
                            DateTime dt = Directory.GetCreationTime(list2[i]);
                            Console.WriteLine(list2[i]);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("Created :");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("{0} ", dt);
                            Console.ResetColor(); ;
                        }
                    }
                    
                   
                }
            }
            catch (UnauthorizedAccessException e)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACCES DANIES SORRY :(");
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException e1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The path encapsulated in the " +
                    "Directory object does not exist. {0}");
                Console.ResetColor();
            }
            

        }
        private static void backUp()
        {
         

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            DriveInfo[] getDr = DriveInfo.GetDrives();
            try
            {
                foreach (var item in getDr)
                {
                    Console.Write("Your Available disk  :");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} :", item.Name);
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("upss");
            }


            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            //
            //path to the directory from which the files will be copied
            //
            Console.WriteLine("Enter drive letter(example c) :");
            string driveLetter = Console.ReadLine();
            Console.WriteLine("In write the directory from which the files are to be copied : (dir\\dir\\)");
            string filePath = Console.ReadLine();
            //
            //path created, displaying files
            //
            string drive = $@"{driveLetter}:\{filePath}";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(drive);
            Console.ResetColor();
            string[] getFiles = Directory.GetFiles(drive,"*.*");

            double mb, kb;
            try
            { 
                Console.WriteLine("\nyou can copy these files\n");
                foreach (var item in getFiles)
                {
                  FileInfo infoFiles = new FileInfo(item);
                  mb = (infoFiles.Length / 1024) / 1024;
                  Console.WriteLine("{0} : {1,10} MB", item, mb);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Upps Danied ;(");
                Console.ResetColor();
            }
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            //
            //creating a copy path
            //
            Console.WriteLine("Enter the disk on which the backup is to be made(example c) :");
            string driveLetter2 = Console.ReadLine();
            Console.WriteLine("Create a path to copy the files : (dir\\dir\\)");
            string filePath2 = Console.ReadLine();
            //
            //creating new directories in which there will be a copy of the files
            //
            string driveBackup = $@"{driveLetter2}:\{filePath2}\";
            if (!Directory.Exists(driveBackup))
            {
                Directory.CreateDirectory(driveBackup);
        
            }
            //
            //copy,and  new file name
            //
            for (int i = 0; i < getFiles.Length; i++)
            {          
                string nameFile = Path.GetFileName(getFiles[i]);
                File.Copy(getFiles[i], $@"{driveLetter2}:\{filePath2}\{i}-backUp-{nameFile}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success {0}",getFiles[i]);
                Console.ResetColor();

            }
            
            
        }
    }
}
