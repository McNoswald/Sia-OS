using System;
using System.IO;
using System.Text;
using SiaOS.Util.Hardware;

namespace SiaOS.Prog
{
    class Calender
    {
        public static void mkcal() 
        {

            if (Kernel.RealH == "false")
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
            else
            {
                RH.RError();
            }
        }
    }
}
