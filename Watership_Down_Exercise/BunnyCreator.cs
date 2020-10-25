using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Watership_Down_Exercise
{
    class BunnyCreator
    {
        private static readonly Random random = new Random();
        public Bunny CreateBunny()
        {
            Bunny bunny;
            //Generate a random color
            Bunny.Color randomColor;
            //Get a random number between 1 and 4
            int randomNumber = random.Next(5);

            switch (randomNumber)
            {
                case 1:
                    randomColor = Bunny.Color.Black;
                    break;
                case 2:
                    randomColor = Bunny.Color.Brown;
                    break;
                case 3:
                    randomColor = Bunny.Color.Spotted;
                    break;
                case 4:
                default:
                    randomColor = Bunny.Color.White;
                    break;
            }
            //Create the bunny with the random color
            bunny = new Bunny(randomColor);

            //[Male/Female] [Black/Brown/Spotted/White] Bunny [Name] Was born!
            Console.WriteLine("{0} {1} Bunny {2} Was born!", bunny.getSex(), bunny.getColor(), bunny.GetName());
            return new Bunny(randomColor);
        }
    }
}
