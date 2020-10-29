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

        private Sex sex;
        private Color color;
        private int age;
        private string name;

        public Sex BunnySex
        {
            get { return this.sex; }
            private set { this.sex = value; }
        }
        public Color BunnyColor
        {
            get { return this.color; }
            private set { this.color = value; }
        }
        public string BunnyName
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        //save the amount of names in a static variable instead of manually typing the amount of names.
        private readonly static int AMOUNT_OF_MALE_NAMES = System.Enum.GetValues(typeof(MaleName)).Length;
        private readonly static int AMOUNT_OF_FEMALE_NAMES = System.Enum.GetValues(typeof(FemaleName)).Length;
        private const int DEFAULT_AGE = 0;
        private const int AMOUNT_OF_SEX_OPTIONS = 2;


        /// <summary>
        /// Create a new bunny from the given params
        /// </summary>
        /// <param name="color"> The bunny's color </param>
        /// <returns> A new bunny with the given properties </returns>
        public Bunny(Color color)
        {
            //Generate the bunny's sex (0 -> male, 1 -> female)
            this.sex = (Sex)random.Next(AMOUNT_OF_SEX_OPTIONS);

            this.color = color;

            this.age = DEFAULT_AGE;

            /* Give the bunny a random name from the name-lists according to its sex */
            if (this.sex == Sex.Male)
            {
                MaleName bunnyName = (MaleName)random.Next(AMOUNT_OF_MALE_NAMES);
                this.name = bunnyName.ToString();
            }
            else
            {
                FemaleName bunnyName = (FemaleName)random.Next(AMOUNT_OF_FEMALE_NAMES);
                this.name = bunnyName.ToString();
            }

        }

    }
}
