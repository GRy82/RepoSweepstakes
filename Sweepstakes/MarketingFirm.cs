using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class MarketingFirm//This class functions to create a sweepstakes
    {
        public ISweepstakesManager _manager;

        public MarketingFirm(ISweepstakesManager _manager)
        {
            this._manager = _manager;
        }

        public void CreateSweepstake()
        {
            string sweepstakesName = UserInterface.GetUserInputFor("\nPlease enter the name of the sweepstakes you are starting: "); 
            Sweepstakes sweepstakes = new Sweepstakes(sweepstakesName);
        }

    }
}
