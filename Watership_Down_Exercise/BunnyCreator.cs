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
        private static readonly Random _random = new Random();

        public static Bunny CreateBunny()
        {
            Bunny bunny;
            Color randomColor;

            //Create the bunny with the random color
            randomColor = GenerateRandomBunnyColor();
            bunny = new Bunny(randomColor);

            return bunny;
        }

        public static Bunny CreateBunny(Sex bunnySex)
        {
            Bunny bunny;
            Color randomColor;

            //Create the bunny with the random color
            randomColor = GenerateRandomBunnyColor();
            bunny = new Bunny(bunnySex, randomColor);

            //[Male/Female] [Black/Brown/Spotted/White] Bunny [Name] Was born!
            //Console.WriteLine(bunny.BunnySex + " " + bunny.BunnyColor + " Bunny " + bunny.BunnyName + " Was born!");
            return bunny;
        }

        public static Bunny CreateBunny(Color color)
        {
            Bunny bunny;

            //Create the bunny with the random color
            bunny = new Bunny(color);

            //[Male/Female] [Black/Brown/Spotted/White] Bunny [Name] Was born!
            //Console.WriteLine(bunny.BunnySex + " " + bunny.BunnyColor + " Bunny " + bunny.BunnyName + " Was born!");
            return bunny;
        }

        private static Color GenerateRandomBunnyColor()
        {
            Color randomColor;
            //Get a random number between 1 and 4
            int randomNumber = _random.Next(AMOUNT_OF_COLORS);

            randomColor = (Color)_random.Next(AMOUNT_OF_COLORS);
            return randomColor;
        }
    }
}
