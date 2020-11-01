using System;
using System.Collections.Generic;
using System.Linq;
using Watership_Down_Exercise.Enum;

namespace Watership_Down_Exercise
{
    /// <summary>
    /// The Hill class is used to simulate a hill that contains bunnies on it.
    /// </summary>
    class Hill
    {
        private ICollection<Bunny> bunniesList;
        int maleBunniesCount;
        int femaleBunniesCount;

        private const int MALE_INITIAL_POPULATION = 2;
        private const int FEMALE_INITIAL_POPULATION = 3;
        private const int ADULT_AGE = 2;
        private const int LIFESPAN = 3;

        /// <summary>
        /// Create the the initial state of the hill.
        /// </summary>
        public Hill()
        {
            this.maleBunniesCount = 0;
            this.femaleBunniesCount = 0;

            this.bunniesList = new HashSet<Bunny>();

            //Create the initial male bunnies
            for (int i = 0; i < MALE_INITIAL_POPULATION; i++)
            {
                Bunny maleBunny = BunnyCreator.CreateBunny(Sex.Male);
                bunniesList.Add(maleBunny);
            }

            //Create the initial female bunnies
            for (int i = 0; i < FEMALE_INITIAL_POPULATION; i++)
            {
                Bunny femaleBunny = BunnyCreator.CreateBunny(Sex.Female);
                bunniesList.Add(femaleBunny);
            }

        }
        /// <summary>
        /// Simulate one year on the hill
        /// </summary>
        public void RunAYear()
        {
            HashSet<Bunny> deadBunniesList = new HashSet<Bunny>();
            for (int i = 0; i < bunniesList.Count; i++)
            {
                Bunny curBunny = bunniesList.ElementAt(i);
                //Make each bunny a year older
                curBunny.GrowAYear();

                //Check if a bunny is too old
                if (curBunny.Age > LIFESPAN)
                {
                    //If the bunny's life is over, the bunny is added to the dead bunnies list :(
                    deadBunniesList.Add(curBunny);
                }
            }
            //Remove all the dead bunnies
            foreach (Bunny bunny in deadBunniesList)
            {
                this.bunniesList.Remove(bunny);
            }

            /*Mate the bunnies to create new bunnies*/
            ICollection<Bunny> maleAdultBunnies = this.GetMaleAdultBunnies();
            ICollection<Bunny> femaleAdultBunnies = this.GetFemaleAdultBunnies();
            ICollection<Bunny> newBunniesList = new HashSet<Bunny>();
            foreach (Bunny fatherBunny in maleAdultBunnies)
            {
                foreach (Bunny motherBunny in femaleAdultBunnies)
                {
                    Color motherColor = motherBunny.BunnyColor;
                    Bunny babyBunny = BunnyCreator.CreateBunny(motherColor);
                    bunniesList.Add(babyBunny);
                    newBunniesList.Add(babyBunny);
                }
            }

            //Print the current state
            this.UpdateBunniesCount();
            Console.WriteLine("There are " + this.maleBunniesCount + " male bunnies, " + this.femaleBunniesCount + " female bunnies (total of " + this.bunniesList.Count + " bunnies).");
            foreach (Bunny bunny in deadBunniesList)
            {
                Console.WriteLine("Bunny " + bunny.BunnyName + " died :(");
            }
            foreach (Bunny bunny in newBunniesList)
            {
                Console.WriteLine("Bunny " + bunny.BunnyName + " was born!");
            }
        }

        /// <summary>
        /// Return a list of all the adult male bunnies
        /// </summary>
        /// <returns></returns>
        private ICollection<Bunny> GetMaleAdultBunnies()
        {
            ICollection<Bunny> maleAdults = new List<Bunny>();
            foreach (Bunny bunny in this.bunniesList)
            {
                if (bunny.BunnySex == Sex.Male && bunny.Age >= ADULT_AGE)
                    maleAdults.Add(bunny);
            }
            return maleAdults;
        }

        /// <summary>
        /// Return a list of all the adult female bunnies
        /// </summary>
        /// <returns></returns>
        private ICollection<Bunny> GetFemaleAdultBunnies()
        {
            ICollection<Bunny> femaleAdults = new List<Bunny>();
            foreach (Bunny bunny in this.bunniesList)
            {
                if (bunny.BunnySex == Sex.Female && bunny.Age >= ADULT_AGE)
                    femaleAdults.Add(bunny);
            }
            return femaleAdults;
        }

        /// <summary>
        /// Update the class members of the amount of male and female bunnies
        /// </summary>
        private void UpdateBunniesCount()
        {
            int malesCount = 0;
            int femalesCount = 0;
            foreach (Bunny bunny in this.bunniesList)
            {
                if (bunny.BunnySex == Sex.Male)
                {
                    malesCount++;
                }
                else
                {
                    femalesCount++;
                }
            }
            this.maleBunniesCount = malesCount;
            this.femaleBunniesCount = femalesCount;
        }
    }
}

