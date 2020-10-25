using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Watership_Down_Exercise
{
    class Bunny
    {
        public enum Sex { Male, Female };
        public enum Color { White, Black, Brown, Spotted };

        private static readonly Random random = new Random();

        private Sex sex;
        private Color color;
        private int age;
        private string name;

        private string[] maleNames = { "Thumper", "Oreo", "Bun", "Coco", "Hopper", "Bono", "Peter", "John" };
        private string[] femaleNames = { "Bunnie", "Lilly", "Daisy", "Violet", "Roxy", "Daphne", "Cinnamon" };


        public Bunny(Color color)
        {
            //Generate the bunny's sex (0 -> male, 1 -> female)
            this.sex = (Sex)random.Next(2);

            this.color = color;

            this.age = 0;

            /* Give the bunny a random name from the name-lists according to its sex */
            if (this.sex == Sex.Male)
                this.name = maleNames[random.Next(maleNames.Length)];
            else
                this.name = femaleNames[random.Next(femaleNames.Length)];

        }

        public Sex getSex()
        {
            return this.sex;
        }

        public Color getColor()
        {
            return this.color;
        }

        public string GetName()
        {
            return this.name;
        }

    }
}
