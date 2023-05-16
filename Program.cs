using KATA_Stratejia;
using System;
using System.Configuration;
using System.IO;


class Program
{
    private static ConsoleLogger Clogger = new ConsoleLogger();
    static void Main(string[] args)
    {
        
        //runWeather();
        //runFootball();
        runDRYVersion();
        
    }

    static void runWeather() //
    {
        try
        {
            Weather weather = new Weather(); 
            string weatherDay = weather.getDayWithLowestSpread(); //Determine which day has lowest spread with the weather.dat file

            if (weatherDay != null)
            {
                Console.WriteLine($"Day where the temperature spread was the lowest: {weatherDay}th\n");

            }
            else
            {
                Console.WriteLine("No valid data found in the file.\n");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void runFootball()
    {
        try
        {
            Football football = new Football(); 
            string team = football.getCityWithLowestDifference(); //Determine which team has lowest difference with the football.dat file

            if (team != null)
            {
                Console.WriteLine($"Team: {team}\n");
            }
            else
            {
                Console.WriteLine("No valid data found in the file.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    

    static void runDRYVersion()
    {
        string answer = "";        
        while (answer != "q")
        {
            Clogger.initialPrompt(); //Call ConsoleLogger class to show the different options for the user
            answer = Clogger.getAnswer(); // Get the answer from the user

            switch (answer)
            {
                case "1":
                    launchFileProcessing("weather.dat", 0, 1, 2, "weather");
                    break;

                case "2":
                    launchFileProcessing("football.dat", 1, 6, 8, "football");
                    break;

                case "q":
                    Clogger.log(ConfigurationManager.AppSettings["goodbye"]);
                    break;

                default:
                    Clogger.log(ConfigurationManager.AppSettings["wrongInput"]);
                    break;
            }
        }
    }

    static void launchFileProcessing(string filename, int col1, int col2, int col3, string p_sentence )
    {
        try
        {
            FileProcessor processor = new FileProcessor(filename);
            string smallestDifferenceLine = processor.FindSmallestDifference(col1, col2, col3);

            if (smallestDifferenceLine != null)
            {
                string sentence = ConfigurationManager.AppSettings[p_sentence];
                Clogger.log(sentence + $" {smallestDifferenceLine}\n");
            }
            else
            {
                Clogger.log(ConfigurationManager.AppSettings["no_data"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
