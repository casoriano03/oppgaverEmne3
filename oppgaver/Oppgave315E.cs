using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace oppgaver
{
    internal class Oppgave315E:IOppgaver
    {
        private int[] numbersArray;

        public void Run()
        {
            var startValue = InputValueConverter("Enter start value: ");
            var endvalue = InputValueConverter("Enter end value: ");
            var interval = InputValueConverter("Enter interval: ");

            PrintNumberArray(startValue, endvalue, interval);

        }


        public void PrintNumberArray(int startValue, int endValue, int interval)
        {
            var currentValue = startValue;
            GenerateArray(startValue, endValue, interval);
            Array.Clear(numbersArray, 0, numbersArray.Length);
            for (var i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = currentValue;
                currentValue += interval;
            }

            Console.WriteLine(string.Join(", ",numbersArray));
        }

        private void GenerateArray(int startValue, int endValue, int interval)
        {
            var difference = endValue - startValue;
            if (difference % interval != 0)
            {
                Console.WriteLine($"Start value {startValue} and End value {endValue} is not divisible by interval {interval}. Please enter another number");
                Run();
            }
            else
            {
                var arraySize = difference / interval;
                numbersArray = new int[arraySize+1];
            }
        }

        private static int InputValueConverter(string message)
        {
            Console.Write($"{message}");
            var numberInput = Console.ReadLine();
            var number = Convert.ToInt32(numberInput);
            return number;
        }
    }
}

