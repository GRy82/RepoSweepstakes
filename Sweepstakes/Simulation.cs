using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Simulation
    {
        public void CreateMarketingFirmWithManager()
        {
            string managementChoice;
            do {
                managementChoice = UserInterface.GetUserInputFor("\nPlease choose how your marketing firm would prefer to manage their sweepstakes. Type 'queue' or 'stack': ");
            } while (managementChoice != "queue" && managementChoice != "stack");
            ISweepstakesManager _manager = Factory.AssignManager(managementChoice);
            //Below, you will see dependency injection at work. The process is contingent on what happens with the line of code seen above. The above static method call passes a  
            //parameter--in this case, provided by user input-- that will be used to signal what type of object should be returned. Because any of the objects returned are inheriting 
            //from ISweepstakesManager, they will be able to be stored in _manager as the ISweepstakesManager interface type.
            //
            //From there, the _manager variable can be passed to the constructor of the MarketingFirm object seen below, at the moment that it is instantiated.  Because that respective
            //constructor takes an ISweepstakesManager type as its parameter, any object of reference type that inherits ISweepstakesManager can be passed in.  
            //
            //With dependency injection, we are able to eliminate a class's dependency, or a method's dependency, on any on one type of object. A certain flexibilty is provided instead.
            //That is the flexibility to use the same needed functionality with different objects of differing reference type.  The encapsulated implementation details may be different 
            //from one object to another, but they can all be interacted with in those ways prescribed by the interface they inherit. 
            MarketingFirm marketingFirm = new MarketingFirm(_manager);
        }
    }
}
