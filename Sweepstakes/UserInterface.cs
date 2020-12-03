using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static string GetUserInputFor(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static Contestant EnterContestantInfo()
        {
            Console.WriteLine("\nEnter the contestant's information here...\n");
            string fName = GetUserInputFor("first name: ");
            string lName = GetUserInputFor("last name: ");
            string email = GetUserInputFor("email address: ");
            int registration = Convert.ToInt32(GetUserInputFor("registration number: "));
            Contestant contestant = new Contestant(fName, lName, email, registration);
            return contestant;
        }
        
    }
}
