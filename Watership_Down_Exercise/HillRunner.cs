using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Watership_Down_Exercise.Enum;


namespace Watership_Down_Exercise
{
    /// <summary>
    /// The HillRunner class is used to load the Hill and run it automatically
    /// </summary>
    class HillRunner
    {

        private Hill _hill;

        private const int SLEEP_TIME = 3000;


        private const string BUNNY = "Bunny";
        private const string NAME = "Name";
        private const string SEX = "Sex";
        private const string AGE = "Age";
        private const string COLOR = "Color";

        /// <summary>
        /// Create the default hill (2 males and 3 females) to run
        /// </summary>
        public HillRunner()
        {
            this._hill = new Hill();
        }

        /// <summary>
        /// Load the hill from an xml file
        /// </summary>
        /// <param name="filePath"></param>
        public HillRunner(string filePath)
        {
            //If the initialization file exists
            if (File.Exists(filePath))
            {
                //Load the hill from the xml file
                this.LoadFromXML(filePath);
            }
            else
            {
                //The file does not exist so the default hill will be created
                this._hill = new Hill();
            }
        }
        /// <summary>
        /// Run a year on the hill and sleep for a few seconds each time. Pause when enter is pressed.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Press ENTER to pause");

                //Run the hill and pause if enter was clicked
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        _hill.RunAYear();
                        Thread.Sleep(SLEEP_TIME);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);

                Console.WriteLine("PAUSED. PRESS ENTER TO CONTINUE");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { /*wait until enter is clicked again*/}

            }
        }
        /// <summary>
        /// Create a hill using a list of bunnies in an xml file located in the path
        /// </summary>
        /// <param name="filePath"></param>
        private void LoadFromXML(string filePath)
        {
            List<Bunny> bunniesList = new List<Bunny>();
            XDocument xml = XDocument.Load(filePath);

            //for each bunny node
            foreach (var node in xml.Root.Descendants())
            {
                //make sure the xml-node is called 'Bunny'
                if (node.Name == BUNNY)
                {
                    XAttribute nameAttribute = node.Attribute(NAME);
                    XAttribute sexAttribute = node.Attribute(SEX);
                    XAttribute ageAttribute = node.Attribute(AGE);
                    XAttribute colorAttribute = node.Attribute(COLOR);

                    bool areAllNotNull = (nameAttribute != null) && (sexAttribute != null)
                        && (colorAttribute != null) && (ageAttribute != null);

                    //if the node has 'Name', 'Sex','Color' and 'Age' in it
                    if (areAllNotNull)
                    {
                        //Save the values into the variables and create a new bunny if they are all valid

                        string name;
                        int age;
                        Sex sex;
                        Color color;

                        name = nameAttribute.Value;

                        string ageString = ageAttribute.Value;
                        bool isAgeValid = int.TryParse(ageString, out age);

                        string sexString = sexAttribute.Value;
                        bool isSexValid = System.Enum.TryParse(sexString, out sex);

                        string colorString = colorAttribute.Value;
                        bool isColorValid = System.Enum.TryParse(colorString, out color);

                        if (isAgeValid && isSexValid && isColorValid)
                        {
                            Bunny bunny = new Bunny(sex, color, name, age);
                            bunniesList.Add(bunny);
                        }
                    }

                }
            }
            //Finally, create the hill with the list of bunnies
            this._hill = new Hill(bunniesList);
        }
    }
}
