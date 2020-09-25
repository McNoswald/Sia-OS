using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.IO;
using Sys = Cosmos.System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SiaOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            //starts the filesystem stuff
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                               Welcome to Sia OS.                               ");
            Console.ResetColor();
            Console.WriteLine("                  Type cmd for a list of commands and Apps. ");
            Console.WriteLine("");
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

        protected override void Run()
        {
            //code for the command line
            Console.Write(Directory.GetCurrentDirectory() + "> ");
            var input = Console.ReadLine().ToLower();

            //misc commands
            if (input.StartsWith("echo "))
            {
                var text = input.Substring(5);

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
                Console.ResetColor();
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Info/help Commands:");
                Console.ResetColor();
                Console.WriteLine(" cmd - Shows all commands");
                Console.WriteLine(" about - about the Operating System");
                //Console.WriteLine(" tshoot - Trouble Shooter");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Misc Commands:");
                Console.ResetColor();
                Console.WriteLine(" cls - Clears the screen");
                Console.WriteLine(" echo - displays the text put after the command.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Test Commands");
                Console.ResetColor();
                Console.WriteLine(" gui - Puts the OS in GUI mode (work in progress)(Works only on VMs)");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("File System (unstable):");
                Console.ResetColor();
                Console.WriteLine(" drive - Displays all drives and their info");
                Console.WriteLine(" dir - displays all files in directory");
                Console.WriteLine(" mkdir - Makes a Directory (Very Unstable)");
                Console.WriteLine(" rmdir - Removes a Directory (Very Unstable)");
                Console.WriteLine(" cd - Changes directory location");
                Console.WriteLine(" open - opens your specified file");
                Console.WriteLine(" del - deletes specified file");
                Console.WriteLine(" copy - copys a file to the location given");
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Basic Programs:");
                Console.ResetColor();
                Console.WriteLine(" time - tells the time");
                Console.WriteLine(" piano - opens the piano program");
                Console.WriteLine(" mkcal - makes a calender");
                Console.WriteLine(" chkcal - checks for a calender on a date given");
                Console.WriteLine(" calc - a basic calculator");
                Console.WriteLine(" text - Text Writer");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Games");
                Console.ResetColor();
                Console.WriteLine(" numguess - A Number Guessing Game");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Power Commands");
                Console.ResetColor();
                Console.WriteLine(" shutdown - Powers off your computer");
                Console.WriteLine(" restart - Restarts your computer");
                Console.WriteLine("");
            }

            else if (input == "gui")
            {
                Console.WriteLine("This GUI is still a W.I.P. The Clock is still being worked on and is not fully\nfunctional.There is nothing to do in the gui mode. It's just for testing");
                Console.ReadLine();
                switch (input)
                {
                    default:
                        Gui();
                        break;



                }

            }

            else if (input == "about")
            {
                //about the OS       
                Console.WriteLine("PC Info:");
                //string computer_name = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
                Console.WriteLine("Ram:" + Cosmos.Core.CPU.GetAmountOfRAM() + "MB");
                Console.WriteLine("\nOS Info:");
                Console.WriteLine("Sia OS 1.0");
                Console.WriteLine("Built on 9/24/2020");
                Console.WriteLine("Sia OS is Created by Evyn Vega and belongs to Sia C.A.T");
            }

            //File System Commands
            else if (input.StartsWith("cd "))
            {
                var cd = input.Substring(3);
                if (cd.StartsWith("0"))
                {

                    try
                    {


                        if (Directory.Exists(cd))
                        {
                            Directory.SetCurrentDirectory(cd);
                        }
                        else
                        {
                            Console.WriteLine("The specified directory does not exist.");
                        }

                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine("The specified directory does not exist. {0}", e);
                    }
                }

                else
                {
                    try
                    {
                        var text = input.Substring(3);
                        var dir = Directory.GetCurrentDirectory();
                        var chdir = (cd);
                        if (Directory.Exists(cd))
                        {
                            Directory.SetCurrentDirectory(dir + "\\" + chdir);
                        }
                        else
                        {
                            Console.WriteLine("The specified directory does not exist.");
                        }

                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine("The specified directory does not exist. {0}", e);
                    }
                }


            }

            else if (input.StartsWith("mkdir "))
            {
                try
                {
                    var dirn = input.Substring(6);
                    var dir = Directory.GetCurrentDirectory();
                    var ndir = (dirn);
                    Directory.CreateDirectory(dir + "\\" + ndir);
                    Console.WriteLine("Directory Made!");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }

            }

            else if (input.StartsWith("rmdir "))
            {
                try
                {
                    var dirn = input.Substring(6);
                    var dir = Directory.GetCurrentDirectory();
                    var ndir = (dirn);
                    Directory.Delete(dir + "\\" + ndir);
                    Console.WriteLine("Directory Deleted!");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }

            }

            else if (input == "dir")
            {
                try
                {

                    string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
                    var drive = new DriveInfo("0");
                    Console.WriteLine("Volume in drive 0 is " + $"{drive.VolumeLabel}");
                    Console.WriteLine("Directory of " + Directory.GetCurrentDirectory());
                    Console.WriteLine("----------------------------");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    for (int i = 0; i < filePaths.Length; ++i)
                    {

                        string path = filePaths[i];
                        Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(path) + " (" + System.IO.Path.GetExtension(path) + ")");
                    }
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory()))
                    {

                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;

                        Console.WriteLine(dirName + " <DIR>");
                    }
                    Console.ResetColor();

                    Console.WriteLine("\n        " + $"{drive.TotalSize}" + " bytes");
                    Console.WriteLine("        " + $"{drive.AvailableFreeSpace}" + " bytes free");




                }


                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }


            }

            else if (input == "drive")
            {
                try
                {
                    DriveInfo[] drives = DriveInfo.GetDrives();

                    foreach (DriveInfo drive in drives)
                    {
                        Console.WriteLine("Drive " + drive.Name);
                        Console.WriteLine("Drive Format: " + drive.DriveFormat);
                        Console.WriteLine("Drive Size: {0}", drive.TotalSize);
                        Console.WriteLine("Drive Free Space: {0}", drive.TotalFreeSpace);


                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }
            }

            else if (input == "text")
            {
                try
                {
                    Console.Write("SiaPad 1.0\n");
                    Console.Write("File Name (put in the extension name):");
                    var finput = Console.ReadLine().ToLower();
                    string fileName = finput;
                    var dir = Directory.GetCurrentDirectory();
                    var file = (fileName);
                    // Check if file already exists. If yes, delete it.     
                    if (File.Exists(dir + "\\" + file))
                    {
                        File.Delete(dir + "\\" + file);
                    }
                    Console.Write("File Contents:\n");
                    var text = Console.ReadLine().ToLower();
                    using (FileStream fs = File.Create(dir + "\\" + file))
                    {
                        // Add some text to file    
                        Byte[] title = Encoding.ASCII.GetBytes(text);
                        fs.Write(title, 0, title.Length);
                    }
                    Console.WriteLine("File Made!");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }
            }

            else if (input.StartsWith("open "))
            {
                var text = input.Substring(5);
                string fileName = text;
                var dir = Directory.GetCurrentDirectory();
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

            else if (input.StartsWith("del "))
            {
                var text = input.Substring(4);
                string fileName = text;
                var dir = Directory.GetCurrentDirectory();
                var file = (fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (File.Exists(dir + "\\" + file))
                    {
                        File.Delete(dir + "\\" + file);
                        Console.WriteLine(text + " was deleted");
                    }

                    else
                    {
                        Console.WriteLine("No File Exists");
                    }

                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }
            }

            else if (input.StartsWith("copy "))
            {
                try
                {
                    var text = input.Substring(5);
                    string fileName = text;
                    var dir = Directory.GetCurrentDirectory();
                    var file = (fileName);

                    var path = dir + "\\" + file;

                    Console.Write("Copy to: ");
                    var copy = Console.ReadLine().ToLower();
                    var outputPath = copy;

                    File.Copy(path, outputPath);
                    Console.WriteLine(fileName + " was copied to " + outputPath);
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }
            }
            
            // Misc Applications
            else if (input == "time")
            {
                DateTime now = DateTime.Now; // <-- Value is copied into local
                Console.WriteLine(now);

            }

            else if (input == "mkcal")
            {
                try
                {
                    Console.Write("What day is this for? (Example: 1-1-2020): ");
                    var finput = Console.ReadLine().ToLower();
                    string calName = finput + ".cal";
                    var dir = Directory.GetCurrentDirectory();
                    var file = (calName);
                    Console.Write("12:00 AM: ");
                    var twea = Console.ReadLine().ToLower();
                    Console.Write("1:00 : ");
                    var onea = Console.ReadLine().ToLower();
                    Console.Write("2:00 : ");
                    var twoa = Console.ReadLine().ToLower();
                    Console.Write("3:00 : ");
                    var thra = Console.ReadLine().ToLower();
                    Console.Write("4:00 : ");
                    var fora = Console.ReadLine().ToLower();
                    Console.Write("5:00 : ");
                    var fiva = Console.ReadLine().ToLower();
                    Console.Write("6:00 : ");
                    var sixa = Console.ReadLine().ToLower();
                    Console.Write("7:00 : ");
                    var seva = Console.ReadLine().ToLower();
                    Console.Write("8:00 : ");
                    var eita = Console.ReadLine().ToLower();
                    Console.Write("9:00 : ");
                    var nina = Console.ReadLine().ToLower();
                    Console.Write("10:00 : ");
                    var tena = Console.ReadLine().ToLower();
                    Console.Write("11:00 : ");
                    var elva = Console.ReadLine().ToLower();
                    Console.Write("12:00 PM: ");
                    var twep = Console.ReadLine().ToLower();
                    Console.Write("1:00 : ");
                    var onep = Console.ReadLine().ToLower();
                    Console.Write("2:00 : ");
                    var twop = Console.ReadLine().ToLower();
                    Console.Write("3:00 : ");
                    var thrp = Console.ReadLine().ToLower();
                    Console.Write("4:00 : ");
                    var forp = Console.ReadLine().ToLower();
                    Console.Write("5:00 : ");
                    var fivp = Console.ReadLine().ToLower();
                    Console.Write("6:00 : ");
                    var sixp = Console.ReadLine().ToLower();
                    Console.Write("7:00 : ");
                    var sevp = Console.ReadLine().ToLower();
                    Console.Write("8:00 : ");
                    var eitp = Console.ReadLine().ToLower();
                    Console.Write("9:00 : ");
                    var ninp = Console.ReadLine().ToLower();
                    Console.Write("10:00 : ");
                    var tenp = Console.ReadLine().ToLower();
                    Console.Write("11:00 : ");
                    var elvp = Console.ReadLine().ToLower();
                    if (File.Exists(dir + "\\" + file))
                    {
                        File.Delete(dir + "\\" + file);
                    }
                    using (FileStream fs = File.Create(dir + "\\" + file))
                    {
                        //12am 
                        Byte[] title = new UTF8Encoding(true).GetBytes("Calender for " + finput + " ");
                        fs.Write(title, 0, title.Length);
                        Byte[] twa = new UTF8Encoding(true).GetBytes("12:00 AM :" + twea + "\n");
                        fs.Write(twa, 0, twa.Length);
                        Byte[] ona = new UTF8Encoding(true).GetBytes("1:00 :" + onea + "\n");
                        fs.Write(ona, 0, ona.Length);
                        Byte[] toa = new UTF8Encoding(true).GetBytes("2:00 :" + twoa + "\n");
                        fs.Write(toa, 0, toa.Length);
                        Byte[] tra = new UTF8Encoding(true).GetBytes("3:00 :" + thra + "\n");
                        fs.Write(tra, 0, tra.Length);
                        Byte[] foa = new UTF8Encoding(true).GetBytes("4:00 :" + fora + "\n");
                        fs.Write(foa, 0, foa.Length);
                        Byte[] fia = new UTF8Encoding(true).GetBytes("5:00 :" + fiva + "\n");
                        fs.Write(fia, 0, fia.Length);
                        Byte[] sia = new UTF8Encoding(true).GetBytes("6:00 :" + sixa + "\n");
                        fs.Write(sia, 0, sia.Length);
                        Byte[] sea = new UTF8Encoding(true).GetBytes("7:00 :" + seva + "\n");
                        fs.Write(sea, 0, sea.Length);
                        Byte[] eia = new UTF8Encoding(true).GetBytes("8:00 :" + eita + "\n");
                        fs.Write(eia, 0, eia.Length);
                        Byte[] nia = new UTF8Encoding(true).GetBytes("9:00 :" + nina + "\n");
                        fs.Write(nia, 0, nia.Length);
                        Byte[] tea = new UTF8Encoding(true).GetBytes("10:00 :" + tena + "\n");
                        fs.Write(tea, 0, tea.Length);
                        Byte[] ela = new UTF8Encoding(true).GetBytes("11:00 :" + elva + "\n");
                        fs.Write(ela, 0, ela.Length);
                        //12pm
                        Byte[] twp = new UTF8Encoding(true).GetBytes("12:00 PM :" + twep + "\n");
                        fs.Write(twp, 0, twp.Length);
                        Byte[] onp = new UTF8Encoding(true).GetBytes("1:00 :" + onep + "\n");
                        fs.Write(onp, 0, onp.Length);
                        Byte[] top = new UTF8Encoding(true).GetBytes("2:00 :" + twop + "\n");
                        fs.Write(top, 0, top.Length);
                        Byte[] trp = new UTF8Encoding(true).GetBytes("3:00 :" + thrp + "\n");
                        fs.Write(trp, 0, trp.Length);
                        Byte[] fop = new UTF8Encoding(true).GetBytes("4:00 :" + forp + "\n");
                        fs.Write(fop, 0, fop.Length);
                        Byte[] fip = new UTF8Encoding(true).GetBytes("5:00 :" + fivp + "\n");
                        fs.Write(fip, 0, fip.Length);
                        Byte[] sip = new UTF8Encoding(true).GetBytes("6:00 :" + sixp + "\n");
                        fs.Write(sip, 0, sip.Length);
                        Byte[] sep = new UTF8Encoding(true).GetBytes("7:00 :" + sevp + "\n");
                        fs.Write(sep, 0, sep.Length);
                        Byte[] eip = new UTF8Encoding(true).GetBytes("8:00 :" + eitp + "\n");
                        fs.Write(eip, 0, eip.Length);
                        Byte[] nip = new UTF8Encoding(true).GetBytes("9:00 :" + ninp + "\n");
                        fs.Write(nip, 0, nip.Length);
                        Byte[] tep = new UTF8Encoding(true).GetBytes("10:00 :" + tenp + "\n");
                        fs.Write(tep, 0, tep.Length);
                        Byte[] elp = new UTF8Encoding(true).GetBytes("11:00 :" + elvp + "\n");
                        fs.Write(elp, 0, elp.Length);
                    }
                    Console.WriteLine("Calender Made!");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

                }

            }

            else if (input == "chkcal")
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

            else if (input == "piano")
            {
                Console.WriteLine("Cat Piano ver 1.0");
                Console.WriteLine("Press any key to continue");
                switch (input)
                {
                    default:
                        Piano();
                        break;



                }
            }

            else if (input == "calc")
            {
                try
                {
                    int firstNum;
                    int secondNum;
                    int thirdNum;
                    //Variables for equation

                    string operation;
                    string operation2;
                    int answer;
                    int answer2;

                    Console.WriteLine("\nHow many integers? 2 or 3?");
                    var inter = Console.ReadLine().ToLower();
                    ;

                    if (inter == "2")
                    {

                        Console.Write("Enter the first number in your equation: ");
                        firstNum = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter your operation ( x , / , +, -) ");
                        operation = Console.ReadLine();

                        //User input for equation
                        Console.Write("Enter your second number in the equation: ");
                        secondNum = Convert.ToInt32(Console.ReadLine());


                        if (operation == "x")
                        {
                            answer = firstNum * secondNum;
                            Console.WriteLine(firstNum + " x " + secondNum + " = " + answer);
                            Console.ReadLine();
                        }
                        else if (operation == "/")
                        {
                            answer = firstNum / secondNum;
                            Console.WriteLine(firstNum + " / " + secondNum + " = " + answer);
                            Console.ReadLine();
                        }
                        //Getting answers
                        else if (operation == "+")
                        {
                            answer = firstNum + secondNum;
                            Console.WriteLine(firstNum + " + " + secondNum + " = " + answer);
                            Console.ReadLine();
                        }
                        else if (operation == "-")
                        {
                            answer = firstNum - secondNum;
                            Console.WriteLine(firstNum + " - " + secondNum + " = " + answer);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Sorry that is not correct format! Please restart.");     //Catch
                            Console.ReadLine();
                        }
                    }
                    else if (inter == "3")
                    {

                        Console.Write("Enter the first number in your equation: ");
                        firstNum = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter your operation ( x , / , +, -) ");
                        operation = Console.ReadLine();

                        //User input for equation
                        Console.Write("Enter your second number in the equation: ");
                        secondNum = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter your operation ( x , / , +, -) ");
                        operation2 = Console.ReadLine();

                        //User input for equation
                        Console.Write("Enter your third number in the equation: ");
                        thirdNum = Convert.ToInt32(Console.ReadLine());

                        if (operation == "x")
                        {
                            answer = firstNum * secondNum;
                            if (operation2 == "x")
                            {
                                answer2 = answer * thirdNum;
                                Console.WriteLine(firstNum + " x " + secondNum + " x " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "/")
                            {
                                answer2 = answer / thirdNum;
                                Console.WriteLine(firstNum + " x " + secondNum + " / " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "+")
                            {
                                answer2 = answer + thirdNum;
                                Console.WriteLine(firstNum + " x " + secondNum + " + " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "-")
                            {
                                answer2 = answer - thirdNum;
                                Console.WriteLine(firstNum + " x " + secondNum + " - " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }

                        }
                        else if (operation == "/")
                        {
                            answer = firstNum / secondNum;
                            if (operation2 == "x")
                            {
                                answer2 = answer * thirdNum;
                                Console.WriteLine(firstNum + " / " + secondNum + " x " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "/")
                            {
                                answer2 = answer / thirdNum;
                                Console.WriteLine(firstNum + " / " + secondNum + " / " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "+")
                            {
                                answer2 = answer + thirdNum;
                                Console.WriteLine(firstNum + " / " + secondNum + " + " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "-")
                            {
                                answer2 = answer - thirdNum;
                                Console.WriteLine(firstNum + " / " + secondNum + " - " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }

                        }
                        //Getting answers
                        else if (operation == "+")
                        {
                            answer = firstNum + secondNum;
                            if (operation2 == "x")
                            {
                                answer2 = answer * thirdNum;
                                Console.WriteLine(firstNum + " + " + secondNum + " x " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "/")
                            {
                                answer2 = answer / thirdNum;
                                Console.WriteLine(firstNum + " + " + secondNum + " / " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "+")
                            {
                                answer2 = answer + thirdNum;
                                Console.WriteLine(firstNum + " + " + secondNum + " + " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "-")
                            {
                                answer2 = answer - thirdNum;
                                Console.WriteLine(firstNum + " + " + secondNum + " - " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }

                        }
                        else if (operation == "-")
                        {
                            answer = firstNum - secondNum;
                            if (operation2 == "x")
                            {
                                answer2 = answer * thirdNum;
                                Console.WriteLine(firstNum + " - " + secondNum + " x " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "/")
                            {
                                answer2 = answer / thirdNum;
                                Console.WriteLine(firstNum + " - " + secondNum + " / " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "+")
                            {
                                answer2 = answer + thirdNum;
                                Console.WriteLine(firstNum + " - " + secondNum + " + " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }
                            else if (operation2 == "-")
                            {
                                answer2 = answer - thirdNum;
                                Console.WriteLine(firstNum + " - " + secondNum + " - " + thirdNum + " = " + answer2);
                                Console.ReadLine();
                            }

                        }

                        else
                        {
                            Console.WriteLine("Sorry that is not correct format! Please restart.");     //Catch

                        }
                    }
                    
                    else
                    {
                        Console.WriteLine("Not a Valid option");
                        Console.ReadLine();
                    }

                }
                catch (Exception Ex)
                {

                    Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                    Console.WriteLine(Ex.ToString());

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
                Console.WriteLine("Thank you for using Sia OS.");
                Console.ReadKey();
                Sys.Power.Shutdown();
            }
            else if (input == "restart")
            {
                Sys.Power.Reboot();
            }

            //if a unknown command is typed a message is displayed
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Sorry that is not a valid command. Type cmd for a list of valid ones.");
                Console.WriteLine("");

            }
        }

        private void Piano()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("|ESC|");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                            Cat Piano 1.0                                  ");
            Console.ResetColor();
            Console.WriteLine("Welcome to Cat Piano 1.0!");
            Console.WriteLine("These are The Following Aviable Keys you can play");
            Console.WriteLine(" |S| |D|  |G||H||J|");
            Console.WriteLine("|Z||X||C||V||B||N||M|");
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                //bottom keys
                if (keyinfo.Key == ConsoleKey.Z)
                {
                    Console.Beep(163, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.X)
                {
                    Console.Beep(183, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.C)
                {
                    Console.Beep(206, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.V)
                {
                    Console.Beep(218, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.B)
                {
                    Console.Beep(244, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.N)
                {
                    Console.Beep(275, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.M)
                {
                    Console.Beep(308, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                //topkeys
                else if (keyinfo.Key == ConsoleKey.S)
                {
                    Console.Beep(173, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.D)
                {
                    Console.Beep(194, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.G)
                {
                    Console.Beep(231, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.H)
                {
                    Console.Beep(259, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.J)
                {
                    Console.Beep(291, 100);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
                else if (keyinfo.Key == ConsoleKey.LeftWindows)
                {
                    Console.WriteLine("Windows key");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|ESC|");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                            Cat Piano 1.0                                  ");
                    Console.ResetColor();
                    Console.WriteLine("Welcome to Cat Piano 1.0!");
                    Console.WriteLine("These are The Following Aviable Keys you can play");
                    Console.WriteLine(" |S| |D|  |G||H||J|");
                    Console.WriteLine("|Z||X||C||V||B||N||M|");
                }
            }
            while (keyinfo.Key != ConsoleKey.Escape);
            Console.Clear();

        }

        private void Gui()
        {
            try
            {
                Cosmos.HAL.Drivers.PCI.Video.VMWareSVGAII driver = new Cosmos.HAL.Drivers.PCI.Video.VMwareSVGAII();

                //Desktop
                driver.SetMode(800, 600);
                driver.Clear(0x65280);

                //taskbar
                for (uint w = 0; w < 800; w++)
                {

                    for (uint h = 0; h < 30; h++)
                    {

                        uint x = w;

                        uint y = 600 - h;

                        driver.SetPixel(x, y, 0xEDE3C7); //SetPixel(x,y,color)

                    }
                }

                //home button
                for (uint w = 0; w < 30; w++)
                {

                    for (uint h = 0; h < 30; h++)
                    {

                        uint x = w;

                        uint y = 600 - h;

                        driver.SetPixel(x, y, 0xFFFFFF); //SetPixel(x,y,color)



                    }
                }



                //Mouse
                Mouse m = new Mouse(800, 600); // Note that you'll have to specify the screen resolution (width and height).
                bool OK = true; // Directly using true will cause debugging issues, and even if you disable it (to make the GUI not lag) it's still very useful to just disable the GUI.
                while (OK)
                {

                    for (uint w = 30; w < 800; w++)
                    {
                        DateTime now = DateTime.Now; // <-- Value is copied into local
                        Console.WriteLine(now);



                        for (uint h = 5; h < 25; h++)
                        {

                            uint x = w;

                            uint y = 600 - h;


                            //Mouse Refresh
                            m.Draw(driver); // Draws the mouse with the specified driver  
                            uint Width = 800;
                            uint Height = 600;
                            driver.Update(0, 0, Width, Height); // Updates the screen as a whole to reduce flicker

                            //taskbar refresh
                            for (uint wi = 30; wi < 800; wi++)
                            {

                                for (uint hi = 0; hi < 30; hi++)
                                {

                                    uint xx = wi;

                                    uint yy = 600 - h;

                                    driver.SetPixel(xx, yy, 0xEDE3C7); //SetPixel(x,y,color)

                                }
                            }

                            //clock
                            if (DateTime.Now.Hour == 1)
                            {


                                driver.SetPixel(394, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(395, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)

                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }
                            if (DateTime.Now.Hour == 7)
                            {


                                driver.SetPixel(394, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(395, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)

                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }
                            if (DateTime.Now.Hour == 13)
                            {


                                driver.SetPixel(394, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(395, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)

                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }
                            if (DateTime.Now.Hour == 19)
                            {


                                driver.SetPixel(394, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(395, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)

                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }
                            if (DateTime.Now.Hour == 22)
                            {

                                //1
                                driver.SetPixel(376, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(376, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(376, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(376, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(376, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(377, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(377, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(377, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(377, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(377, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(378, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(378, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(378, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(378, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(378, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(379, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(379, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(379, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(379, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(379, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(382, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(383, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(384, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(385, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(386, y, 0x000000); //SetPixel(x,y,color)

                                // 0


                                driver.SetPixel(391, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(392, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(393, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)


                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }
                            if (DateTime.Now.Hour == 23)
                            {
                                //1

                                driver.SetPixel(380, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(380, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(381, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(381, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(382, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(382, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(382, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(382, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(382, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(383, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(383, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(383, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(383, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(383, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(384, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(384, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(384, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(384, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(384, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(385, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(385, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(385, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(385, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(385, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(386, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(387, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(388, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(389, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(390, y, 0x000000); //SetPixel(x,y,color)

                                //11
                                driver.SetPixel(394, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(395, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 581, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 582, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 583, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 584, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 585, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)

                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }
                            else
                            {

                                driver.SetPixel(394, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(394, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(395, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(395, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(396, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(396, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(397, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(397, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(398, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(399, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(400, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(401, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(402, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(403, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(404, y, 0x000000); //SetPixel(x,y,color)

                                // :

                                driver.SetPixel(408, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(408, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(408, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(409, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(410, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(411, 591, 0x000000); //SetPixel(x,y,color)

                                //0

                                driver.SetPixel(416, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(417, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(418, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(419, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(420, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(421, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(421, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(422, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(423, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(424, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(425, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(426, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(427, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(428, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(429, y, 0x000000); //SetPixel(x,y,color)

                                //00

                                driver.SetPixel(434, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(435, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(436, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(437, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(438, y, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 580, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 576, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 577, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 578, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 579, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 580, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(439, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(439, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(440, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(441, 591, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 595, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 594, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 593, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 592, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(442, 591, 0x000000); //SetPixel(x,y,color)

                                driver.SetPixel(443, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(444, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(445, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(446, y, 0x000000); //SetPixel(x,y,color)
                                driver.SetPixel(447, y, 0x000000); //SetPixel(x,y,color)

                            }

                        }


                    }
                }
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());
                Console.Beep(275, 300);
                Console.Beep(259, 100);
                Console.Beep(244, 100);
                Console.Beep(231, 600);
            }
        }
    }
}
 