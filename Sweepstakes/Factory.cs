using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class Factory
    {
        public static ISweepstakesManager AssignManager(string managementChoice)
        {
            ISweepstakesManager _manager = null;
            switch (managementChoice)
            {
                case "queue":
                    _manager = new SweepstakesQueueManager();              
                    break;
                case "stack":
                    _manager = new SweepstakesStackManager();
                    break;
            }
            return _manager;
        }
    }
}
