using System;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using SiaOS.Prog;
using SiaOS.Util;
using SiaOS.Util.Hardware;
using SiaOS.FS;

namespace SiaOS
{
    public class Kernel : Sys.Kernel
    {
        protected static bool enabled;
        public static CosmosVFS fs;
        internal static string file;

        // From Aura OS. I just need this for cd only to work because im to lazy to go make everything use this
        public static string current_directory = @"0:\";
        public static string current_volume = @"0:\";

        public static string username;
        public static string pcolor = "Black";
        public static string shell;
        public static string time;
        public static string date;

        public static string real;

        protected override void BeforeRun()
        {
            if (RH.onRealHardware() == true)
            {
                RH.RealHardwareAlert();
            }
            //starts the filesystem stuff
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            //Check for Username and start Setup
            if (RH.onRealHardware() == true)
            {
            }
            else
            {
                if (File.Exists(@"0:\SYSTEM\Username.set"))
                {
                    username = File.ReadAllText(@"0:\SYSTEM\Username.set");
                }

                else
                {
                    Setup.SetupStart();
                }

                if (File.Exists(@"0:\SYSTEM\Color.set"))
                {
                    pcolor = File.ReadAllText(@"0:\SYSTEM\Color.set");
                    Bcolor();
                }
                if (File.Exists(@"0:\SYSTEM\Date&Time.set"))
                {
                    if (File.ReadAllText(@"0:\SYSTEM\Date&Time.set").Contains("12hour"))
                    {
                        time = "12hour"; 
                    }
                    else
                    {
                        time = "24hour";
                    }
                   
                }


             }
            Console.ResetColor();
            Bcolor();
            Console.Clear();
            printLogoConsole();
            Console.WriteLine("\n");
            Console.WriteLine("Type cmd for a list of commands and Apps. ");
            Console.WriteLine("");
            if (RH.onRealHardware() == true)
            {

            }
            else
            {
                var root = @"0:\";
                Directory.SetCurrentDirectory(root);
                if (File.Exists(DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + ".cal"))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Reminder: You have a Calender for Today! Type 'open " + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + ".cal' to veiw it.\n");
                    Console.ResetColor();
                }
            }
        }
        
        protected override void Run()
        {

            //code for the command line
            if (RH.onRealHardware() == true)
            {
                Console.Write(username + "> ");
            }
            else
            {
                Console.Write(username + "| " + current_directory + "> ");
            }
            var input = Console.ReadLine().ToLower();
            shell = input;
            //misc commands
            if (input.StartsWith("echo "))
            {
                var text = Kernel.shell.Substring(5);

                Console.WriteLine(text);
            }

            else if (input == "cls")
            {
                Console.Clear();
            }

            //info amd help
           else if (input == "cmd")
            {
                //lists all commands
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("|List of Commands/Apps|");
                Bcolor();
                Console.WriteLine("");
             
                Console.WriteLine("Info/help Commands:");
                Bcolor();
                Console.WriteLine(" cmd - Shows all commands");
                Console.WriteLine(" about - about the Operating System");
                Console.WriteLine(" new - New Features in Build");
                Console.WriteLine(" help - Gives more info on Commands");
  
                Console.WriteLine("Misc Commands:");
                Bcolor();
                Console.WriteLine(" cls - Clears the screen");
                Console.WriteLine(" echo - Repeats Text Given");
   
                Console.WriteLine("File System:");
                Bcolor();
                Console.WriteLine(" drive - Displays drive info");
                Console.WriteLine(" dir - displays all files and sub-dirs in directory");
                Console.WriteLine(" mkdir - Makes a Directory");
                Console.WriteLine(" rmdir - Removes a Directory");
                Console.WriteLine(" cd - Changes current directory");
                Console.WriteLine(" type - Quickly Types out file content (use MIV to view files)");
                Console.WriteLine(" del - deletes specified file");
                Console.WriteLine(" copy - copies a file to the location given");
                Console.WriteLine(" move - moves a file to the location given");
                Console.WriteLine(" format - Formats the drive");
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();

                Console.WriteLine("Programs:");
                Bcolor();
                Console.WriteLine(" time - tells the time");
                Console.WriteLine(" piano - Piano Program");
                Console.WriteLine(" mkcal - Creates a calender");
                Console.WriteLine(" chkcal - checks for a calender");
                Console.WriteLine(" calc - Simple calculator");
                Console.WriteLine(" MIV - Text Editor");
   
                Console.WriteLine("Games:");
                Bcolor();
                Console.WriteLine(" numguess - A Number Guessing Game");
         
                Console.WriteLine("Power Commands:");
                Bcolor();
                Console.WriteLine(" shutdown - Powers off your computer");
                Console.WriteLine(" restart - Restarts your computer");
                Console.WriteLine("");
            }

            else if (input == "about")
            {
                //about the OS       
                Console.WriteLine("PC Info:");
                Console.WriteLine("Ram:" + Cosmos.Core.CPU.GetAmountOfRAM() + "MB");
                Console.WriteLine("\nOS Info:");
                Console.WriteLine("Sia OS 1.1");
                Console.WriteLine("Built on 11/11/2020");
                Console.WriteLine("Sia OS is Created by Evyn Vega");
                Console.WriteLine("Cosmos belongs to the COSMOS Project");
                Console.WriteLine("Some code in the project is not mine and some are from the Cobalt and Aura \nProjects");
            }

            else if (input == "new")
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("|Whats New in 1.1?|\n");
                Bcolor();
                Console.WriteLine("Features and Additions");
                Console.WriteLine("- Format Command");
                Console.WriteLine("- Help Command");
                Console.WriteLine("- MIV Text Editor");
                Console.WriteLine("- Move Command");
                Console.WriteLine("- What's New Command");
                Console.WriteLine("- Setup name, time, and color prefrence");
                Console.WriteLine("- Real hardware detection");
                Console.WriteLine("Changes:");
                Console.WriteLine("- Changed Start-Up Appearance");
                Console.WriteLine("- Minor Changes in Text");
                Console.WriteLine("- You must now Setup Sia OS");
                Console.WriteLine("- Removal of GUI");
            }

            //File System Commands
            else if (input.StartsWith("cd "))
            {
                if (RH.onRealHardware() == false)
                {
                    chngdir.cd();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input.StartsWith("mkdir "))
            {
                if (RH.onRealHardware() == false)
                {
                    mkd.mkdir();
                }
                else
                {
                    RH.RError();
                }

            }

            else if (input.StartsWith("rmdir "))
            {
                if (RH.onRealHardware() == false)
                {
                    rmd.rmdir();
                }
                else
                {
                    RH.RError();
                }

            }

            else if (input == "dir")
            {
                if (RH.onRealHardware() == false)
                {
                    Files.dir();
                }
                else
                {
                    RH.RError();
                }


            }

            else if (input == "drive")
            {
                if (RH.onRealHardware() == false)
                {
                    DRV.drives();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input == "miv")
            {
                if (RH.onRealHardware() == false)
                {
                    MIV.StartMIV();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input.StartsWith("type "))
            {
                if (RH.onRealHardware() == false)
                {
                    open.type();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input.StartsWith("del "))
            {
                if (RH.onRealHardware() == false)
                {
                    dl.del();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input.StartsWith("copy "))
            {
                if (RH.onRealHardware() == false)
                {
                    cpy.copy();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input.StartsWith("move "))
            {
                if (RH.onRealHardware() == false)
                {
                    mv.move();
                }
                else
                {
                    RH.RError();
                }
            }

            else if (input == "format")
            {
                if (RH.onRealHardware() == false)
                {
                    frm.format();
                }
                else
                {
                    RH.RError();
                }

            }

            // Misc Applications
            else if (input == "time")
            {
                
                if (time == "12hour")
                {
                    Console.WriteLine(DateTime.UtcNow);
                }
                else
                {
                    Console.WriteLine(DateTime.Now);
                }
            }

            else if (input == "mkcal")
            {
                Calender.mkcal();

            }

            else if (input == "chkcal")
            {
                if (RH.onRealHardware() == false)
                {
                    try
                    {
                        Console.Write("What day do you want to check for (Example: 1-1-2020): ");
                        var day = Console.ReadLine().ToLower();
                        if (File.Exists(day + ".cal"))
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You have a Calender! Type 'open " + day + ".cal' to veiw it.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("You have no calenders for that day");
                        }
                    }
                    catch (Exception Ex)
                    {

                        Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                        Console.WriteLine(Ex.ToString());

                    }
                }
                else
                {
                   RH.RError();
                }
            }

            else if (input == "piano")
            {
                Console.WriteLine("Cat Piano ver 1.0");
                Console.WriteLine("Press any key to continue");
                
                Piano.Pian();
                        
            }

            else if (input == "calc")
            {
                Calculator.Calc();
            }

            else if (input == "setup")
            {
                if (RH.onRealHardware() == false)
                {
                   Setup.SetupStart();
                }
                else
                {
                    RH.RError();
                }
            }

            //Games
            else if (input == "numguess")
            {
                try
                {
                    Random random = new Random();

                    int returnValue = random.Next(1, 100);
                    int Guess = 0;
                    int numGuesses = 0;

                    Console.WriteLine("I am thinking of a number between 1-100.  Can you guess what it is?");

                    while (Guess != returnValue)
                    {
                        Guess = Convert.ToInt32(Console.Read());
                        string line = Console.ReadLine(); // Get string from user
                        if (!int.TryParse(line, out Guess)) // Try to parse the string as an integer
                            Console.WriteLine("Not an integer!");
                        else
                        {
                            numGuesses++;
                            if (Guess < returnValue)
                            {
                                Console.WriteLine("No, the number I am thinking of is higher than " + Guess + " .  Can you guess what it is?");
                            }
                            if (Guess > returnValue)
                            {
                                Console.WriteLine("No, the number I am thinking of is lower than " + Guess + " .  Can you guess what it is");
                            }
                        }
                    }
                    Console.WriteLine("Well done! The answer was " + returnValue + ".\nYou took " + numGuesses + " guesses.");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }
            }

            //Power
            else if (input == "shutdown")
            {
                //from Colbot OS
                int sec = 10;
                while (sec > 0)
                {
                    Console.WriteLine("Thank You for using Sia OS. Your computer will shutdown in  " + sec + " seconds, or press any key to shutdown now.");
                    sec--;
                    WaitSeconds(1);

                    if (System.Console.KeyAvailable == true)
                    {
                        Cosmos.System.Power.Shutdown();
                    }
                    else if (sec == 0)
                    {
                        Cosmos.System.Power.Shutdown();
                    }
                    Console.Clear();
                   
                }
                
            }

            else if (input == "restart")
            {
                Sys.Power.Reboot();
            }

            //if a unknown command is typed then nothing
            else
            {

            }
        }

        //from Cobolt OS
        public static void WaitSeconds(int secNum)
        {
            int StartSec = Cosmos.HAL.RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (Cosmos.HAL.RTC.Second != EndSec) { }
        }
        private static void printLogoConsole()
        {
            Console.Clear();
            Console.WriteLine("     ##### #######  #####    ##### #####");
            Console.WriteLine("    #        #     #   #    #   # #");
            Console.WriteLine("     ####   #     #####    #   # ##### ");
            Console.WriteLine("       #  #     #   #    #   #     #");
            Console.WriteLine(" ##### ####### #   #    ##### #####     Version 1.1");
        }
        
        public static void Bcolor()
        {
           
            if (pcolor == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (pcolor == "white")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (pcolor == "blue")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (pcolor == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void Exit()
        {
            Console.Clear();
        }

    }

}

 