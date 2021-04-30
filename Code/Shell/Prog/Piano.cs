using System;

namespace SiaOS.Prog
{
    class Piano
    {
        public static void Pian()
        {

            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Piano 2.0");
            Console.WriteLine("These are The Following Aviable Keys you can play.To end this program press the End button.");
            Console.WriteLine(" |S| |D|  |G||H||J|    |2| |3|  |5||6||7|");
            Console.WriteLine("|Z||X||C||V||B||N||M|||Q||W||E||R||T||Y||U||I|");
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
                else if (keyinfo.Key == ConsoleKey.Q)
                {
                     Console.Beep(327, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.W)
                {
                     Console.Beep(367, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.E)
                {
                     Console.Beep(412, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.R)
                {
                     Console.Beep(436, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.T)
                {
                     Console.Beep(489, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.Y)
                {
                     Console.Beep(550, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.U)
                {
                     Console.Beep(617, 100);
                     Console.Clear();
                Pian();
                }
                else if (keyinfo.Key == ConsoleKey.I)
                {
                     Console.Beep(654, 100);
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
                else if (keyinfo.Key == ConsoleKey.D2)
                {
                    Console.Beep(346, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.D3)
                {
                    Console.Beep(388, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.D5)
                {
                    Console.Beep(462, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.D6)
                {
                    Console.Beep(519, 100);
                    Console.Clear();
                    Pian();
                }
                else if (keyinfo.Key == ConsoleKey.D7)
                {
                    Console.Beep(582, 100);
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