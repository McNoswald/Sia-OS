using System;
using System.IO;

namespace SiaOS.FS
{
    class chngdir
    {
        public static void cd()
        {
           
            var cd = Kernel.shell.Substring(3);
            if (cd.StartsWith("0"))
            {

                try
                {


                    if (Directory.Exists(cd))
                    {
                        Kernel.current_directory = cd;
                        Directory.SetCurrentDirectory(cd);



                    }
                    else
                    {
                        Console.WriteLine("The specified directory does not exist.");
                    }

                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("The specified directory does not exist. {0}", e);
                }
            }
            else if (cd == "..")
            {

                try
                {
                    //code from Aura OS
                    Directory.SetCurrentDirectory(Kernel.current_directory);
                    var root = Kernel.fs.GetDirectory(Kernel.current_directory);
                    if (Kernel.current_directory == Kernel.current_volume)
                    {
                    }
                    else
                    {
                        Kernel.current_directory = root.mParent.mFullPath;
                    }
                    Directory.SetCurrentDirectory(Kernel.current_directory);

                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("The specified directory does not exist. {0}", e);
                }
            }
            else
            {
                try
                {
                    var text = Kernel.shell.Substring(3);
                    var dir = Directory.GetCurrentDirectory();
                    var chdir = (cd);
                    if (Directory.Exists(cd))
                    {
                        Kernel.current_directory = dir + "\\" + chdir;
                        Directory.SetCurrentDirectory(dir + "\\" + chdir);


                    }
                    else
                    {
                        Console.WriteLine("The specified directory does not exist.");
                    }

                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("The specified directory does not exist. {0}", e);
                }
            }
        }
    }
}
