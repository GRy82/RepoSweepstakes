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

        public MarketingFirm(string name)
        {
            this.name = name;
        }

        void CreateSweepstakes()
        {

        }
        //Use dependency injection to utilize sweepstakes management type of choice.
        //Make sure to document where dependency is being injected and why it is useful.
    }
}
