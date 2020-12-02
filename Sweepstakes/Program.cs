using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Sweepstakes Management System. To get started, enter your name or the name of your firm. ");
            string nameInput;
            do
            {
                nameInput = Console.ReadLine();
            } while (nameInput.Length < 2 || nameInput.Length > 25);
            MarketingFirm marketingFirm = new MarketingFirm(nameInput);
        }
    }
}
