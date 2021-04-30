using System;
using System.IO;

namespace SiaOS.FS
{
    class DRV
    {
        public static void drives()
        {
            //from Colbolt OS
            try
            {
                Console.Write("Detected Drives: ");
                Console.WriteLine(DriveInfo.GetDrives().Length);
                foreach (DriveInfo d in DriveInfo.GetDrives())
                {
                    Console.WriteLine(" - " + d.Name + " " + (d.TotalSize / 1048576) + "MB");
                   

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
