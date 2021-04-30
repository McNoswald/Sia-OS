using System;
using System.IO;

namespace SiaOS.FS
{
    class open
    {
        public static void type()
        {
            var text = Kernel.shell.Substring(5);
            string fileName = text;
            var dir = Kernel.current_directory;
            var file = (fileName);

            try
            {

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(dir + "\\" + file))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);


                    }
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
