using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA_Stratejia
{
    internal class Weather
    {
        public string getDayWithLowestSpread()
        {
            string filename = "weather.dat";
            string day = "";
            double smallestDifference = double.MaxValue;

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    try
                    {
                        string columnAValue = parts[0];
                        double columnBValue = double.Parse(parts[1]);
                        double columnCValue = double.Parse(parts[2]);
                        double difference = Math.Abs(columnBValue - columnCValue);


                        if (difference < smallestDifference)
                        {
                            smallestDifference = difference;
                            day = columnAValue;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            return day;
        }
    }
}
