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
            Contestant winner = contestants[winnerIndex];
            SendMessages(winner);
            return winner;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"\nfirst name: {contestant.firstName}\nlast name: {contestant.lastName}\nemail address:" +
                $" {contestant.emailAddress}\nregistration number: {contestant.registrationNumber}");
        }



        //Use of API, MailKit by JStedfast
        void SendMessages(Contestant winner)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(this.Name, "gwryan@buffalo.edu"));
            message.Subject = "The results of the " + this.Name + "Sweepstakes!!";
            for (int i = 0; i < contestants.Count; i++)
            {
                message.To.Clear();
                message.To.Add(new MailboxAddress(contestants[i].firstName + contestants[i].lastName, contestants[i].emailAddress));
                if (contestants[i] == winner) {
                    message = TailorMessageToWinner(message, winner);
                }
                else{
                    message = TailorMessageToLoser(message, winner);
                }
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.buffalo.edu", 587, false);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }

        private MimeMessage TailorMessageToWinner(MimeMessage message, Contestant winner)
        {
            message.Body = new TextPart("plain")
            {
                Text = $@"Congratulations, {winner.firstName} {winner.lastName}!!! You are the winner of our sweepstakes. Hopefully you kept that receipt so you can claim your prize!"
            };
            return message;
        }

        private MimeMessage TailorMessageToLoser(MimeMessage message, Contestant winner)
        {
            message.Body = new TextPart("plain")
            {
                Text = $@"Thank you so much for your participation in our sweepstakes. Unfortunately, you are not the winner this time around. We'd like to congratulate the winner of our sweepstakes, {winner.firstName} {winner.lastName}!!!"
            };
            return message;
        }
    }
}
