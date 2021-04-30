using System;

namespace SiaOS.FS
{
    class frm
    {
        public static void format()
        {
            Console.WriteLine("ARE YOU SURE? ALL DATA WILL BE LOST ON YOUR HARDDRIVE! \n(TYPE YES TO CONFIRM)");
            if (Console.ReadLine() == "yes")
            {
                try
                {
                    Console.WriteLine("Formating...");
                    Kernel.fs.Format(@"0:\", "FAT32", true);
                    Console.WriteLine("Done!");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("A Error Ocurred while trying to format the drive.");
                    Console.WriteLine(Ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("Operation Cancelled, No changes were made.");
            }
        }
    }
}
