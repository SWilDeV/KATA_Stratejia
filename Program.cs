using KATA_Stratejia;
using System;
using System.Configuration;
using System.IO;


class Program
{
    private static ConsoleLogger Clogger = new ConsoleLogger();
    static void Main(string[] args)
    {
        //runBasic();

        runDRYVersion();
        
    }

    static void runBasic()
    {
        string answer = "";
        while (answer != "q")
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Weather comparison");
            Console.WriteLine("2 - Football comparison");
            Console.WriteLine("q - quit");
            answer = Console.ReadLine();

            switch (answer)
            {
            case "1":

                try
                {
                    Weather weather = new Weather();
                    string weatherDay = weather.getDayWithLowestSpread();

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
                break;

            case "2":

                try
                {
                    Football football = new Football();
                    string team = football.getCityWithLowestDifference();

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
                break;
            case "q":
                Console.WriteLine("Goodbye !");
                break;
            default:

                Console.WriteLine("Wrong input");
                break;
            }
        }

    }

    static void runDRYVersion()
    {
        string answer = "";        
        while (answer != "q")
        {
            Clogger.initialPrompt();
            answer = Clogger.getAnswer();

            switch (answer)
            {
                case "1":
                    launchProcessing("weather.dat", 0, 1, 2, "weather");
                    break;

                case "2":
                    launchProcessing("football.dat", 1, 6, 8, "football");
                    break;

                case "q":
                    Clogger.log("Goodbye !");
                    break;

                default:

                    Clogger.log("Wrong input\n");
                    break;
            }
        }
    }

    static void launchProcessing(string filename, int col1, int col2, int col3, string p_sentence )
    {
        try
        {
            CSVProcessor processor = new CSVProcessor(filename);
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
