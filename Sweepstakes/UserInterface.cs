using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {

        
       

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
