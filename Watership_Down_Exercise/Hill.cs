using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watership_Down_Exercise.Enum;

namespace Watership_Down_Exercise
{
    /// <summary>
    /// The Hill class is used to simulate a hill that contains bunnies on it.
    /// </summary>
    class Hill
    {
        private List<Bunny> bunniesList;
        private const int MALE_INITIAL_POPULATION = 2;
        private const int FEMALE_INITIAL_POPULATION = 3;
        private const int ADULT_AGE = 2;
        private const int LIFESPAN = 10;

        public Hill()
        {
            bunniesList = new List<Bunny>();

            //Create the male bunnies
            for (int i = 0; i < MALE_INITIAL_POPULATION; i++)
            {
                Bunny maleBunny = BunnyCreator.CreateBunny(Sex.Male);
                bunniesList.Add(maleBunny);
            }

            //Create the female bunnies
            for (int i = 0; i < FEMALE_INITIAL_POPULATION; i++)
            {
                Bunny femaleBunny = BunnyCreator.CreateBunny(Sex.Female);
                bunniesList.Add(femaleBunny);
            }

        }

        public void RunAYear()
        {

            for (int i = 0; i < bunniesList.Count; i++)
            {
                //Make each bunny a year older
                bunniesList[i].GrowAYear();

                //Check if a bunny is too old
                if (bunniesList[i].Age > LIFESPAN)
                {
                    //If the bunny's life is over, the bunny is removed from the list
                    Console.WriteLine("Bunny " + bunniesList[i].BunnyName + "died :(");
                    bunniesList.RemoveAt(i);
                }


            }
        }

        private List<Bunny> GetMaleAdultBunnies()
        {
            List<Bunny> maleAdults = new List<Bunny>();
            foreach (Bunny bunny in this.bunniesList)
            {
                if (bunny.BunnySex == Sex.Male && bunny.Age >= ADULT_AGE)
                    maleAdults.Add(bunny);
            }
            return maleAdults;
        }

        private List<Bunny> GetFemaleAdultBunnies()
        {
            List<Bunny> femaleAdults = new List<Bunny>();
            foreach (Bunny bunny in this.bunniesList)
            {
                if (bunny.BunnySex == Sex.Female && bunny.Age >= ADULT_AGE)
                    femaleAdults.Add(bunny);
            }
            return femaleAdults;
        }

    }
}
