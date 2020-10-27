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
             List<Bunny> bunnies = new List<Bunny>();
 
             /* Create 5 bunnies */
             for (int i = 0; i < 5; i++)
             {
                 Bunny newBunny = BunnyCreator.CreateBunny();
                 bunnies.Add(newBunny);
             }
         }
     }
 }
