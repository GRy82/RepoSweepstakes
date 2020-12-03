using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        public Dictionary<int, Contestant> contestants = new Dictionary<int, Contestant> { };
        private string name;
        public string Name { get => name; set => name = value; }

        public Contestant this[int index]
        {
            get { return contestants[index]; }

            set { contestants[index] = value;  }
        }

        public Sweepstakes(string name)
        {
            this.name = name;
        }

        public void RegisterContestant(Contestant contestant)
        {
            contestants.Add(contestant.registrationNumber, contestant);
        }

        public Contestant PickWinner()
        {
            Random rand = new Random();
            int winnerIndex = rand.Next(0, contestants.Count);
            return contestants[winnerIndex];
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"\nfirst name: {contestant.firstName}\nlast name: {contestant.lastName}\nemail address:" +
                $" {contestant.emailAddress}\nregistration number: {contestant.registrationNumber}");
        }

    }
}
