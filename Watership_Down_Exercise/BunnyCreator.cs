using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watership_Down_Exercise.Enum;

namespace Watership_Down_Exercise
{
    /// <summary>
    /// The BunnyCreator class is used to create bunnies
    /// </summary>
    static class BunnyCreator
    {
        const int AMOUNT_OF_COLORS = 4;
        private static readonly Random random = new Random();

        public static Bunny CreateBunny()
        {
            Bunny bunny;
            Color randomColor;
            //Get a random number between 1 and 4
            int randomNumber = random.Next(AMOUNT_OF_COLORS);

            //Generate a random color
            switch (randomNumber)
            {
                case 0:
                    randomColor = Color.Black;
                    break;
                case 1:
                    randomColor = Color.Brown;
                    break;
                case 2:
                    randomColor = Color.Spotted;
                    break;
                case 3:
                default:
                    randomColor = Color.White;
                    break;
            }
            //Create the bunny with the random color
            bunny = new Bunny(randomColor);

            //[Male/Female] [Black/Brown/Spotted/White] Bunny [Name] Was born!
            Console.WriteLine(bunny.BunnySex + " " + bunny.BunnyColor + " Bunny " + bunny.BunnyName + " Was born!");
            return bunny;
        }
    }
}
