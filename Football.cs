using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA_Stratejia
{
    internal class Football
    {
        private string filename = "football.dat";

        public Football() { }
        public string getCityWithLowestDifference()
        {
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
                        double goalsConceded = double.Parse(parts[8]);
                        double difference = Math.Abs(goalsScored - goalsConceded);

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
