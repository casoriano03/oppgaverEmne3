using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppgaver
{
    internal class Oppgave315A: IOppgaver
    {
        int tryCount = 0;
        public void Run()
        {
            randomNumber();
        }

        public void randomNumber()
        {
            var random = new Random();
            var number = random.Next(1, 100);
            var isNumberNotGuessed = true;
           
            Console.WriteLine("Please guess the correct number from 1 - 100");

            while (isNumberNotGuessed)
            {
                var numberInput = Console.ReadLine();
                var guessedNumber = Convert.ToInt32(numberInput);
                if (guessedNumber == number)
                {
                    isNumberNotGuessed = false;
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                    Console.WriteLine($"You did it in {tryCount} tries.");
                } else if (guessedNumber > number)
                {
                    wrongAnswer("higher");
                } else if (guessedNumber < number)
                {
                    wrongAnswer("lower");
                }
            }
        }

        public void wrongAnswer(string position)
        {
            tryCount++;
            Console.WriteLine($"You guessed a {position} number. Try again");
        }
    }
}
