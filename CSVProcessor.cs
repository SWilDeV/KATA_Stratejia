using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA_Stratejia
{
    internal class CSVProcessor
    {
        public string Filename { get; }

        public CSVProcessor(string filename)
        {
            Filename = filename;
        }

        public string FindSmallestDifference(int finalInfoColumn, int value1, int value2)
        {
            string smallestDifferenceElement = "";
            double smallestDifference = double.MaxValue;

            using (StreamReader reader = new StreamReader(Filename))
            {
                string line;
                reader.ReadLine(); 

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    try
                    {
                        string finalInfo = parts[finalInfoColumn];
                        double columnValue1 = double.Parse(parts[value1]);
                        double columnValue2 = double.Parse(parts[value2]);
                        double difference = Math.Abs(columnValue1 - columnValue2);


                        if (difference < smallestDifference)
                        {
                            smallestDifference = difference;
                            smallestDifferenceElement = finalInfo;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            return smallestDifferenceElement;
        }

    }
}
