using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        public Dictionary<string, Contestant> contestants = new Dictionary<string, Contestant> { };
        public List<string> contestantNames = new List<string>{}; 
        public string name;
        public string managementType;
        public uint registrationNumberLength;
        public Sweepstakes(string name, uint registrationNumberLength)
        {
            this.name = name;
            this.registrationNumberLength = registrationNumberLength;
        }

        public void RegisterContestant(Contestant contestant)
        {
            string firstAndLast = contestant.firstName + " " + contestant.lastName;
            contestants.Add(firstAndLast, contestant);
        }

        public Contestant PickWinner()
        {
            string winnerName = "";
            Random rand = new Random();
            int winnerPseudoIndex = rand.Next(0, contestants.Count);
            int counter = 0;
            foreach (KeyValuePair<string, Contestant> contestant in contestants)
            {
                if (counter == winnerPseudoIndex) {
                    winnerName = contestant.Key;
                    break;
                }
                counter++;
            }
            Contestant winner = contestants[winnerName];
            return winner;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"first name: {contestant.firstName}\nlast name: {contestant.lastName}\nemail address:" +
                $" {contestant.emailAddress}\nregistration number: {contestant.registrationNumber}");
        }

    }
}
