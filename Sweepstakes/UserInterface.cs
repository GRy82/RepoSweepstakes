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
            Console.WriteLine("Choose what system you would like to use for managing the sweepstakes you run.\nEnter 1 for Queue system. Enter 2 for Stack system.");
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
                Console.WriteLine("What would you like to do next?\n Enter 1 to create a sweepstakes.\nEnter 2 to manage a sweepstakes.\nEnter 3 to exit Sweepstakes Manager.");
                int choice = GetInput(2);
                if (choice == 1)
                {
                    marketingFirm.managementSystem.InsertSweepstakes();
                }
                else if (choice == 2)
                {

                }
                else
                {
                    Environment.Exit(-1);
                }
            }
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
    }
}
