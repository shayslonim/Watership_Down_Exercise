using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watership_Down_Exercise
{
    class Program
    {
        //The main program
        private const string XML_FILE_PATH = "../../InitialState.xml";
        static void Main(string[] args)
        {
            //Hill hill = new Hill();
            ////Start the hill
            //hill.RunAYear();
            ////Run another year by clicking the enter key. Any other key will be ignored.
            //while (true)
            //{
            //    if (Console.ReadKey().Key == ConsoleKey.Enter)
            //    {
            //        hill.RunAYear();
            //    }
            //}

            HillRunner hillRunner = new HillRunner(XML_FILE_PATH);
            hillRunner.Run();
        }
    }
}
