using System;
using System.IO;

namespace SiaOS.FS
{
    class Files
    {
        public static void dir()
        {
            try
            {
                string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
                var drive = new DriveInfo("0");
                Console.WriteLine("Volume in drive is " + $"{drive.VolumeLabel}");
                Console.WriteLine("Directory of " + Directory.GetCurrentDirectory());
                Console.WriteLine("----------------------------");

               for (int i = 0; i < filePaths.Length; ++i)
               {

                        string path = filePaths[i];
                        Console.Write(System.IO.Path.GetFileNameWithoutExtension(path) + " (" + System.IO.Path.GetExtension(path) + ")  ");
               }

               Console.ForegroundColor = ConsoleColor.Yellow;
               foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory()))
               {

                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;

                        Console.Write(" <" + dirName + "> ");
               }
                Kernel.Bcolor();
                Console.WriteLine("\n        " + $"{drive.TotalSize}" + " bytes");
                Console.WriteLine("        " + $"{drive.AvailableFreeSpace}" + " bytes free");
            }


            catch (Exception Ex)
            {
                Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                Console.WriteLine(Ex.ToString());

            }
        }

        public static void diropt()
        {
            try
            {
                string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
                var drive = new DriveInfo("0");
                Console.WriteLine("Volume in drive is " + $"{drive.VolumeLabel}");
                Console.WriteLine("Directory of " + Directory.GetCurrentDirectory());
                Console.WriteLine("----------------------------");
                var dirtype = Kernel.shell.Substring(4);
                if (dirtype == "/w")
                {





                    for (int i = 0; i < filePaths.Length; ++i)
                    {

                        string path = filePaths[i];
                        Console.Write(System.IO.Path.GetFileNameWithoutExtension(path) + " (" + System.IO.Path.GetExtension(path) + ")  ");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory()))
                    {

                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;

                        Console.Write(" <" + dirName + "> ");
                    }
                    Kernel.Bcolor();
                }
                else if (dirtype == "/l")
                {
                    for (int i = 0; i < filePaths.Length; ++i)
                    {

                        string path = filePaths[i];
                        Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(path) + " (" + System.IO.Path.GetExtension(path) + ")");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory()))
                    {

                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;

                        Console.WriteLine(dirName + " <DIR>");
                    }
                    Kernel.Bcolor();
                }
                else
                {
                    for (int i = 0; i < filePaths.Length; ++i)
                    {

                        string path = filePaths[i];
                        Console.Write(System.IO.Path.GetFileNameWithoutExtension(path) + " (" + System.IO.Path.GetExtension(path) + ")  ");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory()))
                    {

                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;

                        Console.Write(" <" + dirName + "> ");
                    }
                    Kernel.Bcolor();
                }
                Console.WriteLine("\n        " + $"{drive.TotalSize}" + " bytes");
                Console.WriteLine("        " + $"{drive.AvailableFreeSpace}" + " bytes free");
            }


            catch (Exception Ex)
            {
                Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                Console.WriteLine(Ex.ToString());

            }
        }

    }
}
