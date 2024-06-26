﻿using System;
using System.Linq;
using System.IO;
namespace BooleanOutputApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Question 1 - Database Design///
            ////DatabaseDesign.sql file Entity folder///

            ////Question 2.1 Checking if a feature is enable////
            Console.WriteLine(IsFeatureEnabled("00000000", 7));
            Console.WriteLine(IsFeatureEnabled("00000010", 7));
            Console.WriteLine(IsFeatureEnabled("11111111", 4));
            Console.Read();

            ///Question 2.2 Storing user setting////
            ////write settings to file////
            WriteSettingsToFile("11111111");
            Console.Read();
            ////read settings from file////
            Console.WriteLine(ReadSettings("./settings.txt"));
            Console.Read();

        }

        public static bool IsFeatureEnabled(string settings, int setting)
        {
            //get actual index of setting
            int index = setting - 1;

            //convert string to array
            string[] settingsArray = settings.Select(x => x.ToString()).ToArray();

            //check if index value is equal to 1
            return settingsArray[index] == "1";
        }


        ////write settings to file////
        public static void WriteSettingsToFile(string settings)
        {

            using (StreamWriter writetext = new StreamWriter("settings.txt"))
            {
                writetext.WriteLine(settings);
            }
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./settings.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
                writer.WriteLine(settings);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open settings.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
        }

        ////read settings////
        public static string ReadSettings(string filepath)
        {
            try
            {
                string settings = File.ReadAllText(filepath);
                return settings;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot read settings.txt");
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}