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
            stack.Push(sweepstakes);
        }

        public Sweepstakes GetSweepstakes()
        {
            int counter = 1;
            Console.WriteLine("Choose which sweeptakes you want to manage:");
            Sweepstakes[] sweepArray = new Sweepstakes[stack.Count];
            foreach (Sweepstakes contest in stack)
            {

                Console.WriteLine(counter + " " + contest.name);
                sweepArray[counter - 1] = contest;
                counter++;
            }
            int choice = UserInterface.GetInput(counter - 1);
            Sweepstakes sweepstakes = sweepArray[choice];
            return sweepstakes;
        }
    }
}
