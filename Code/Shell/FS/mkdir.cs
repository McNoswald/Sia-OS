using System;

namespace SiaOS.FS
{
    class mkd
    {
        public static void mkdir()
        {
            try
            {
                var dirn = Kernel.shell.Substring(6);
                Kernel.fs.CreateDirectory(Kernel.current_directory + dirn);
                Console.WriteLine("Directory Made!");
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                Console.WriteLine(Ex.ToString());

            }
        }
    }
}
