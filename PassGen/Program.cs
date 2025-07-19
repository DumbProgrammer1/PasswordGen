using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml;

namespace PassWordGen
{

    class PassGen
    {

        private static string executablePath = Environment.ProcessPath;
        private static string directory = Path.GetDirectoryName(executablePath);
        private static string mainFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(directory)));
        public static string Folder = mainFolder + "\\Passwords";
        public static string Txt = Folder + "\\Passwords.txt";
        private static void CreateFiles()
        {

            
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); }
            if (!File.Exists(Txt)) { File.Create(Txt); Process currentProcess = Process.GetCurrentProcess(); Thread.Sleep(3000); Console.Clear();
                    Process.Start(currentProcess.MainModule.FileName);
                        Environment.Exit(0); }
                
        }

        static string Generator()
        {
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            string Pass = "";


                for (int i = 0; i < 14; i++)
                {
                    Pass += chars[rand.Next(chars.Length)];
                }
            
            return Pass;
        }

        public static void Main(string[] args)
        {

            Console.Title = "PassWord Generator";
            CreateFiles();
            string Pass = Generator();
            Console.Write($"Generated Password > {Pass}\n");
            Console.Write("1 = yes, 2 = no \nWould you like to save the password? > "); string input = Console.ReadLine();

                        if (input == "1")
            {
                Console.Write("Name/App For Password > "); string Name = Console.ReadLine();
                string Output = Name + ": " + Pass;
                File.AppendAllText(Txt, Output + Environment.NewLine);
                Console.Write($"Saved to {Txt}\n");
            }
            else if (input == "2")
            {
                Console.Write("password is not saved!\n");
            } Console.Clear(); Console.Write("1= yes, 2 = no,\nGet a new Password? > "); input = Console.ReadLine();
            if (input == "1") { Main(args); }
            else if (input == "2")
            {
                Console.Write("\nExiting"); Thread.Sleep(2500); Environment.Exit(0);
            }
                Console.ReadKey();

        }

    }

}