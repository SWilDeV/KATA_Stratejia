using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA_Stratejia
{
    internal class ConsoleLogger : Logger
    {
        public void log(string msg)
        {
            Console.WriteLine(msg);
        }

        public string getAnswer()
        {
            return Console.ReadLine();
        }
        public void initialPrompt()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Weather comparison");
            Console.WriteLine("2 - Football comparison");
            Console.WriteLine("q - quit");
        }
    }
}
