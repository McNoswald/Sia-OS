using System;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace SiaOS.Util
{
    class Setup
    {
        public static void SetupStart()
        {
            try
            {
                //either you successfully complete set up or it acts like a brat and ruins the harddrive.
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine("|Sia OS Setup|");
                Console.WriteLine("\nThis is the Setup for Sia OS. We will just collect info and were finished.");
                Console.WriteLine("-Type cont to continue");
                Console.WriteLine("-Type exit to continue without Setup");
                Console.WriteLine("-Type anything else to cancel and shutdown");
                var input = Console.ReadLine().ToLower();
                if (input == "cont")
                {

                  
                        Setup2();
                    
                }
                else if (input == "exit")
                {
                    Kernel.username = "user";

                }
                else
                {
                    Cosmos.System.Power.Shutdown();
                }
            }
            catch (Exception Ex)
            {
                Console.ResetColor();
                Console.WriteLine("Setup has failed. Try again by typing setup at prompt");

                Console.WriteLine(Ex.ToString());
                Console.ReadKey();

            }
        }

        public static void Setup2()
        {
            FileStream writeStream = File.Create(@"0:\Prvntcor.set");
            byte[] toWrite = Encoding.ASCII.GetBytes("The Only Purpose of this file is to prevent corruption");
            writeStream.Write(toWrite, 0, toWrite.Length);
            writeStream.Close();

            Console.Clear();
            Console.WriteLine("|Sia OS Setup|");
            Console.WriteLine("\nFirst tell us your name, first name is fine.");
            Console.Write("\nName: ");
            string user = Console.ReadLine().ToLower();
            Console.WriteLine("So your name is " + user + "? Type yes to confirm");
            var input = Console.ReadLine().ToLower();
            if (input == "yes")
            {

                Console.WriteLine("Hello " + user + ", Welcome to Sia OS! Lets Continue on with setup.");
                Console.ReadKey();

                if (Directory.Exists(@"0:\System\"))
                {
                    
                }
                else
                {
                    Kernel.fs.CreateDirectory(@"0:\System\");
                }

                if (File.Exists(@"0:\System\Username.set"))
                {
                    File.Delete(@"0:\System\Username.set");
                }
                FileStream writeStream2 = File.Create(@"0:\System\Username.set");
                byte[] toWrite2 = Encoding.ASCII.GetBytes(user);
                writeStream2.Write(toWrite2, 0, toWrite2.Length);
                writeStream2.Close();
                Setup3();
                
            }
            else
            {
                Console.WriteLine("Ok lets try that again");
                Console.ReadKey();
                Setup2();
            }
        }

        public static void Setup3()
        {
            Console.Clear();
            Console.WriteLine("|Sia OS Setup|");
            Console.WriteLine("\nNow it's time for your prefrences. What Time format do you use?");
            Console.WriteLine("type 12hour or 24hour.");
            Console.Write("\nTime Format: ");
            var tformat = Console.ReadLine().ToLower();

            Console.WriteLine("So you want to use the " + tformat + " format?");
            var input = Console.ReadLine().ToLower();
            if (input == "yes")
            {
                Console.WriteLine("Alright let's move on!");
                Console.ReadKey();
                if (File.Exists(@"0:\System\Date&Time.set"))
                {
                    File.Delete(@"0:\System\Date&Time.set");
                }
                FileStream writeStream2 = File.Create(@"0:\System\Date&Time.set");
                byte[] toWrite2 = Encoding.ASCII.GetBytes("Time: " + tformat);
                writeStream2.Write(toWrite2, 0, toWrite2.Length);
                writeStream2.Close();
                Setup5();
            }
            else
            {
                Console.WriteLine("Ok lets try that again");
                Console.ReadKey();
                Setup3();
            }



        }

        //color setup is gone but if you want it just change the "Setup5();" at the end of Setup 3 to "Setup4();"
        public static void Setup4()
        {
            Console.Clear();
            Console.WriteLine("|Sia OS Setup|");
            Console.WriteLine("\nNow what color would you like to have as the background?");
            Console.WriteLine("- White - Gray - Red - Blue - Green - Default");
            var input = Console.ReadLine().ToLower();
            if (input == "white")
            {
                Console.WriteLine("Alright so you would like " + input + " as your color. Let's move on!");
                Console.ReadKey();
                if (File.Exists(@"0:\System\Color.set"))
                {
                    File.Delete(@"0:\System\Color.set");
                }
                FileStream writeStream2 = File.Create(@"0:\System\Color.set");
                byte[] toWrite2 = Encoding.ASCII.GetBytes(input);
                writeStream2.Write(toWrite2, 0, toWrite2.Length);
                writeStream2.Close();
                Setup5();
            }
            else if (input == "red")
            {
                Console.WriteLine("Alright so you would like " + input + " as your color. Let's move on!");
                    Console.ReadKey();
                if (File.Exists(@"0:\System\Color.set"))
                {
                    File.Delete(@"0:\System\Color.set");
                }
                FileStream writeStream2 = File.Create(@"0:\System\Color.set");
                byte[] toWrite2 = Encoding.ASCII.GetBytes(input);
                writeStream2.Write(toWrite2, 0, toWrite2.Length);
                writeStream2.Close();
                Setup5();
            }
            else if (input == "blue")
            {
                Console.WriteLine("Alright so you would like " + input + " as your color. Let's move on!");
                Console.ReadKey();
                if (File.Exists(@"0:\System\Color.set"))
                {
                    File.Delete(@"0:\System\Color.set");
                }
                FileStream writeStream2 = File.Create(@"0:\System\Color.set");
                byte[] toWrite2 = Encoding.ASCII.GetBytes(input);
                writeStream2.Write(toWrite2, 0, toWrite2.Length);
                writeStream2.Close();
                Setup5();
            }
            else if (input == "green")
            {
                Console.WriteLine("Alright so you would like " + input + " as your color. Let's move on!");
                Console.ReadKey();
                if (File.Exists(@"0:\System\Color.set"))
                {
                    File.Delete(@"0:\System\Color.set");
                }
                FileStream writeStream2 = File.Create(@"0:\System\Color.set");
                byte[] toWrite2 = Encoding.ASCII.GetBytes(input);
                writeStream2.Write(toWrite2, 0, toWrite2.Length);
                writeStream2.Close();
                Setup5();
            }
            else if (input == "default")
            {
                Console.WriteLine("Alright so you would like " + input + " as your color. Let's move on!");
                Console.ReadKey();
                Setup5();
            }
           
        }

        public static void Setup5()
        {
            Console.Clear();
            Console.WriteLine("|Sia OS Setup|");
            Console.WriteLine("\nSetup is complete! Enjoy using Sia OS.");
            Console.ReadKey();
            Sys.Power.Reboot();
        }

    }
}
