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

        public MarketingFirm(string name)
        {
            this.name = name;
            this.managementSystem = ChooseManagementStyle();
        }

        ISweepstakesManager ChooseManagementStyle()
        {
            Console.WriteLine("Choose what system you would like to use for managing the sweepstakes you run.\nEnter 1 for Queue system. Enter 2 for Stack system.");
            int choiceNumber = Program.GetInput(2);
            if(choiceNumber == 1) {
                return new SweepstakesQueueManager();
            }
            else {
                return new SweepstakesStackManager();
            }
        }

        void CreateSweepstakes()
        {

        }
        //Use dependency injection to utilize sweepstakes management type of choice.
        //Make sure to document where dependency is being injected and why it is useful.
    }
}
