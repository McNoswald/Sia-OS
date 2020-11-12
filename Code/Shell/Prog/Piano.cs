using System;

namespace SiaOS.Prog
{
    class Piano
    {
        public static void Pian()
        {

            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Cat Piano 1.0!");
            Console.WriteLine("These are The Following Aviable Keys you can play");
            Console.WriteLine(" |S| |D|  |G||H||J|");
            Console.WriteLine("|Z||X||C||V||B||N||M|");
            ConsoleKeyInfo keyinfo;
           
                keyinfo = Console.ReadKey();
                //bottom keys
                if (keyinfo.Key == ConsoleKey.Z)
                {
                    Console.Beep(163, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.X)
                {
                    Console.Beep(183, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.C)
                {
                    Console.Beep(206, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.V)
                {
                    Console.Beep(218, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.B)
                {
                    Console.Beep(244, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.N)
                {
                    Console.Beep(275, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.M)
                {
                    Console.Beep(308, 100);
                    Console.Clear();
                    Pian();
                }
                //topkeys
                else if (keyinfo.Key == ConsoleKey.S)
                {
                    Console.Beep(173, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.D)
                {
                    Console.Beep(194, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.G)
                {
                    Console.Beep(231, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.H)
                {
                    Console.Beep(259, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.J)
                {
                    Console.Beep(291, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.End)
                {
                    Kernel.Exit();
                }
                else
                {
                    Console.Clear();
                    Pian();
                }
            

        }

    }
}