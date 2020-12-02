using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        public Dictionary<string, Contestant> dictionary = new Dictionary<string, Contestant> { };
        public string name;
        public string managementType;
        public Sweepstakes(string name)
        {
            this.name = name;
        }

        public void RegisterContestant(Contestant contestant)
        {
            string firstAndLast = contestant.firstName + contestant.lastName;
            dictionary.Add(firstAndLast, contestant);
        }

        public Contestant PickWinner()
        {

        }

        public void PrintContestantInfo(Contestant contestant)
        {

        }

    }
}
