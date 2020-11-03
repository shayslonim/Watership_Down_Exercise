using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watership_Down_Exercise.Enum;
namespace Watership_Down_Exercise
{
    /// <summary>
    /// The Bunny class represents a bunny in the hill to simulate a bunny's life.
    /// </summary>
    class Bunny
    {
        private static readonly Random random = new Random();

        public Sex BunnySex { get; private set; }
        public Color BunnyColor { get; private set; }
        public string BunnyName { get; private set; }

        public int Age { get; private set; }

        //save the amount of names in a static variable instead of manually typing the amount of names.
        private readonly static int AMOUNT_OF_MALE_NAMES = System.Enum.GetValues(typeof(MaleName)).Length;
        private readonly static int AMOUNT_OF_FEMALE_NAMES = System.Enum.GetValues(typeof(FemaleName)).Length;

        private const int DEFAULT_AGE = 0;
        private const int AMOUNT_OF_SEX_OPTIONS = 2;


        /// <summary>
        /// Create a new bunny from the given color. Generate a random sex and name.
        /// </summary>
        /// <param name="color"> The bunny's color </param>
        /// <returns> A new bunny with the given properties </returns>
        public Bunny(Color color)
        {
            //Generate the bunny's sex (0 -> male, 1 -> female)
            this.BunnySex = (Sex)random.Next(AMOUNT_OF_SEX_OPTIONS);

            this.BunnyColor = color;
            this.Age = DEFAULT_AGE;
            this.BunnyName = GenerateRandomName(this.BunnySex);

        }
        /// <summary>
        /// Create a new bunny from the given params. Generate a random name.
        /// </summary>
        /// <param name="bunnySex">the bunny's sex</param>
        /// <param name="color">the bunny's color</param>
        public Bunny(Sex bunnySex, Color color)
        {
            this.BunnySex = bunnySex;
            this.BunnyColor = color;
            this.Age = DEFAULT_AGE;
            this.BunnyName = GenerateRandomName(this.BunnySex);


        }
        /// <summary>
        /// Create a new bunny from the given params
        /// </summary>
        /// <param name="sex">the bunny's sex</param>
        /// <param name="color">the bunny's color</param>
        /// <param name="name">the bunny's name</param>
        /// <param name="age">the bunny's age</param>
        public Bunny(Sex sex, Color color, string name, int age)
        {
            BunnySex = sex;
            BunnyColor = color;
            BunnyName = name;
            Age = age;
        }



        /// <summary>
        /// Simulate the growth of the bunny by a year
        /// </summary>
        public void GrowAYear()
        {
            this.Age++;
        }

        /// <summary>
        /// An auxiliary static function that generates the bunny's random sex.
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        private static string GenerateRandomName(Sex sex)
        {
            String chosenName;
            /* Generate a random name from the name-lists according to its sex */
            if (sex == Sex.Male)
            {
                MaleName bunnyName = (MaleName)random.Next(AMOUNT_OF_MALE_NAMES);
                chosenName = bunnyName.ToString();
            }
            else
            {
                FemaleName bunnyName = (FemaleName)random.Next(AMOUNT_OF_FEMALE_NAMES);
                chosenName = bunnyName.ToString();
            }
            return chosenName;
        }
    }
}
