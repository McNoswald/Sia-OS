using System;
using System.Collections.Generic;
using System.Text;

namespace SiaOS.Util.Hardware
{
    class RH
    {
        public static bool onRealHardware()
        {
            if (Cosmos.HAL.PCI.GetDevice(Cosmos.HAL.VendorID.VMWare, Cosmos.HAL.DeviceID.SVGAIIAdapter) != null || Cosmos.HAL.PCI.GetDevice(Cosmos.HAL.VendorID.Bochs, Cosmos.HAL.DeviceID.BGA) != null || Cosmos.HAL.PCI.GetDevice(Cosmos.HAL.VendorID.VirtualBox, Cosmos.HAL.DeviceID.VBVGA) != null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        public static void RealHardwareAlert()
        {
            Console.WriteLine("Warning: Sia OS Detected that this is running on Real Hardware or a Unsupported VM. Because of this the FileSystem will be disabled.");
            Console.ReadKey();
        }
        public static void RError()
        {
            Console.WriteLine("Sorry but you can't do this on Real Hardware or this VM. If you like you can \ntype rhoff at prompt to disable it.");

        }
        
    }
}
