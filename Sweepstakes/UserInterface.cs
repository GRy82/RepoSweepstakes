using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {

        public static MarketingFirm SetupMarketingFirm()
        {
            Console.WriteLine("Welcome to Sweepstakes Management System. To get started, enter your name or the name of your firm.");
            string name = GetInput("string");
            Console.WriteLine("\nChoose what system you would like to use for managing the sweepstakes you run.\nEnter 1 for Queue system.\nEnter 2 for Stack system.");
            int choiceNumber = GetInput(2);
            //ISweepstakesManager managementSystemChoice = (choiceNumber == 1) ? new SweepstakesQueueManager() : new SweepstakesStackManager();
            ISweepstakesManager managementSystemChoice;
            if (choiceNumber == 1){
                managementSystemChoice = new SweepstakesQueueManager();
            }
            else {
                managementSystemChoice = new SweepstakesStackManager();
            }
            return new MarketingFirm(name, managementSystemChoice);
        }

        public static void LoopedMenu(MarketingFirm marketingFirm)
        {
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do next?\nEnter 1 to create a sweepstakes.\nEnter 2 to manage a sweepstakes.\nEnter 3 to exit Sweepstakes Manager.");
                int choice = GetInput(2);
                if (choice == 1)
                {
                    Sweepstakes sweepstakes = marketingFirm.CreateSweepstakes();
                    marketingFirm.managementSystem.InsertSweepstakes(sweepstakes);
                }
                else if (choice == 2)
                {
                    Sweepstakes sweepstakes = marketingFirm.managementSystem.GetSweepstakes();
                    SweepstakeMenu(sweepstakes);
                }
                else
                {
                    Environment.Exit(-1);
                }
            }
        }
       

        private static void SweepstakeMenu(Sweepstakes sweepstakes)
        {
            Console.WriteLine("\nWhat would you like to do with this sweepstakes?\nEnter 1 to register a contestant.\nEnter 2 to print a contestant's info.\nEnter 3 to chose a winner for the sweepstakes.");
            int choice = GetInput(3);
            if (choice == 1) {
                Contestant contestant = EnterContestantInfo();
                sweepstakes.RegisterContestant(contestant);

            }
            else if (choice == 2) {
                Console.WriteLine("\nEnter the first and last name of the contestant(eg. John Smith)");
                string name = GetInput("string");
                sweepstakes.PrintContestantInfo(sweepstakes.contestants[name]);
            }
            else {
                Contestant winner = sweepstakes.PickWinner();
                Console.WriteLine($"\nThe winner of {sweepstakes.name} is {winner.firstName} {winner.lastName}!!!");
            }
        }

        private static Contestant EnterContestantInfo()
        {
            Console.Write("\nEnter contestant's\nfirst name: ");
            string fName = GetInput("string");
            Console.Write("last name: ");
            string lName = GetInput("string");
            Console.Write("email address: ");
            string emailAddress = GetInput("string");
            Console.Write("registration number(5 digits): ");
            uint regNumLength = 5;
            uint registrationNumber = GetInput(regNumLength);
            Contestant contestant = new Contestant(fName, lName, emailAddress, registrationNumber);
            return contestant;
        }

        public static string GetInput(string inputType)
        {
            string nameInput;
            do
            {
                nameInput = Console.ReadLine();
            } while (nameInput.Length < 2 || nameInput.Length > 25);
            return nameInput;
        }

        public static int GetInput(int inputChoices)
        {
            inputChoices = inputChoices + 48; //48 is difference between number and ascii value. 
            string numberInput;
            do
            {
                numberInput = Console.ReadLine();
            } while (numberInput.Length != 1 && (numberInput[0] < 49 || numberInput[0] > inputChoices));
            int numberChosen = Convert.ToInt32(numberInput);
            return numberChosen;
        }
        public static uint GetInput(uint length)
        {
            bool solelyNumeric = true;
            string numberInput;
            do
            {
                numberInput = Console.ReadLine();
                foreach (char character in numberInput) {
                    solelyNumeric = (character < 48 || character > 57) ? false : true;
                    if (solelyNumeric == false) {
                        break;
                    }
                }
            } while (numberInput.Length != length || !solelyNumeric);
            uint numberChosen = Convert.ToUInt32(numberInput);
            return numberChosen;
        }
    }
}
