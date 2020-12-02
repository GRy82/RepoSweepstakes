using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        public Stack<Sweepstakes> stack = new Stack<Sweepstakes> { };
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            Console.WriteLine("Please enter the name of the SweepStakes.");
            string name = UserInterface.GetInput("string");
            stack.Push(new Sweepstakes(name));
        }

        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes;
            return sweepstakes;

        }
    }
}
