using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class MarketingFirm//This class functions to create a sweepstakes
    {
        public string name;
        public ISweepstakesManager managementSystem;

        public MarketingFirm(string name, ISweepstakesManager managementSystem)
        {
            this.name = name;
            this.managementSystem = managementSystem;
        }

        public Sweepstakes CreateSweepstakes()
        {
            Console.WriteLine("Please enter the name of the sweepstakes you are starting.");
            string sweepstakesName = UserInterface.GetInput("string");
            Console.WriteLine("How long should registration numbers be? Think about the intended scope of this sweepstakes.");
            uint maxCap = 1; //represents number of digits that user's input can contain.
            uint registrationLength = UserInterface.GetInput(maxCap);          
            Sweepstakes newSweepstakes = new Sweepstakes(sweepstakesName, registrationLength);
            return newSweepstakes;
        }

        //Use dependency injection to utilize sweepstakes management type of choice.
        //Make sure to document where dependency is being injected and why it is useful.
    }
}
