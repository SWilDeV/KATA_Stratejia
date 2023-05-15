using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA_Stratejia
{
    internal class Football
    {
        public string getCityWithLowestDifference()
        {
            string filename = "football.dat";
            string city = "";
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
                        string TeamCity = parts[1];
                        double goalsScored = double.Parse(parts[6]);
                        double goalsConcided = double.Parse(parts[8]);
                        double difference = Math.Abs(goalsScored - goalsConcided);

                        if (difference < smallestDifference)
                        {
                            smallestDifference = difference;
                            city = TeamCity;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            return city;
        }
    }
}
