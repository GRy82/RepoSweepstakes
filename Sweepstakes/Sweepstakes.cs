using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Sweepstakes
{
    public class Sweepstakes : IObservable<Contestant>
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

        public IDisposable Subscribe(IObserver<Contestant> observer)
        {
            int counter = 0;
            for (int i = 0; i < contestants.Count; i++)
            {
                if (observer != contestants[i]) {
                    counter++;
                }
            }
            if(counter == contestants.Count)
            {
                contestants.Add(contestants.Count, (Contestant)observer);
            }

            return new Unsubscribe(contestants, (Contestant)observer); 
        }

        public void RegisterContestant(Contestant contestant)
        {
            this.Subscribe(contestant);
        }

        public Contestant PickWinner()
        {
            Random rand = new Random();
            int winnerIndex = rand.Next(0, contestants.Count);
            Contestant winner = contestants[winnerIndex];
            foreach (KeyValuePair<int, Contestant> item in contestants)
            {
                if (item.Value == winner)  {
                    item.Value.status = "winner";
                }
                else {
                    item.Value.status = "loser";
                }
                item.Value.OnNext(winner);
            }
            return winner;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"\nfirst name: {contestant.firstName}\nlast name: {contestant.lastName}\nemail address:" +
                $" {contestant.emailAddress}\nregistration number: {contestant.registrationNumber}");
        }



        //Use of API, MailKit by JStedfast
        
    }
}
