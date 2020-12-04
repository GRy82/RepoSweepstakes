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
    public class Contestant : IObserver<Contestant>
    {
        public string firstName;
        public string lastName;
        public string emailAddress;
        public int registrationNumber;
        public string status = "competing";

        public Contestant(string firstName, string lastName, string emailAddress, int registrationNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.registrationNumber = registrationNumber;
        }

        public void OnNext(Contestant winner)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sweepstakes Runners", "marketingFirmEmail.com"));
            message.To.Add(new MailboxAddress(this.firstName + this.lastName, this.emailAddress));
            message.Subject = "The results of the Sweepstakes!!"; 
            if (this.status == "winner")
            {
                message = TailorMessageToWinner(message, winner);
            }
            else
            {
                message = TailorMessageToLoser(message, winner);
            }
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("marketingFirmEmail.com", "Password");
                client.Send(message);
                client.Disconnect(true);
            }
        }
        

        public void OnError(Exception error)
        {

        }


        public void OnCompleted()
        {

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
