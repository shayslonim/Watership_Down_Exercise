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
        static void Main(string[] args)
        {
            const int NUMBER_OF_BUNNIES = 5;
            List<Bunny> bunnies = new List<Bunny>();

            /* Create the bunnies */
            for (int i = 0; i < NUMBER_OF_BUNNIES; i++)
            {
                Bunny newBunny = BunnyCreator.CreateBunny();
                bunnies.Add(newBunny);
            }
        }
    }
}
