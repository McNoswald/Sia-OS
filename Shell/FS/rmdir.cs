using System;
using System.IO;

namespace SiaOS.FS
{
    class rmd
    {
        public static void rmdir()
        {
            try
            {
                var dirn = Kernel.shell.Substring(6);
                var dir = Kernel.current_directory;
                var ndir = (dirn);
                Directory.Delete(dir + "\\" + ndir);
                Console.WriteLine("Directory Deleted!");
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                Console.WriteLine(Ex.ToString());

            }
        }
    }
}
