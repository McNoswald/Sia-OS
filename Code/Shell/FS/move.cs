using System;
using System.IO;

namespace SiaOS.FS
{
    class mv
    {
        public static void move()
        {
            try
            {
                // Basically a modified copy command
                var text = Kernel.shell.Substring(5);
                string fileName = text;
                var dir = Kernel.current_directory;
                var file = (fileName);
                var curr = Kernel.current_directory;

                var path = dir + "\\" + file;

                Console.Write("Move to (Type Full Path): ");
                var copy = Console.ReadLine().ToLower();
                var outputPath = copy;

                if (Directory.Exists(curr))
                {
                    File.Copy(path, outputPath);
                    File.Delete(path);
                    Console.WriteLine(fileName + " was copied to " + outputPath);
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
