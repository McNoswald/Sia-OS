using System;
using System.IO;

namespace SiaOS.FS
{
    class dl
    {
        public static void del()
        {
            var text = Kernel.shell.Substring(4);
            string fileName = text;
            var dir = Kernel.current_directory;
            var file = (fileName);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(dir + "\\" + file))
                {
                    File.Delete(dir + "\\" + file);
                    Console.WriteLine(text + " was deleted");
                }

                else
                {
                    Console.WriteLine("No File Exists");
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                Console.WriteLine(Ex.ToString());

            }
        }
    }
}
