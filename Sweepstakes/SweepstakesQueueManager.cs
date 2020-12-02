using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        public Queue<Sweepstakes> queue = new Queue<Sweepstakes> { };
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            Console.WriteLine("Please enter the name of the SweepStakes.");
            string name = UserInterface.GetInput("string");
            queue.Enqueue(new Sweepstakes(name));
        }

        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes;
            return sweepstakes;

        }
    }
}
