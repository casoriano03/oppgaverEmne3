using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace oppgaver
{
    internal class Oppgave315H: IOppgaver
    {
        static readonly int range = 250;
        int[] counts = new int[range];
        string text = "something";
        int nonZeroCharCount = 0;
        public void Run()
        {
            CounterInputLoop();
        }

        public void CounterInputLoop()
        {
            
            while (!string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Enter text for character count");
                text = Console.ReadLine().ToLower();
                CharacterCounter();
                WriteCharacterAndCount();
            }
        }

        public void CharacterCounter()
        {
            foreach (var character in text)
            {
                counts[(int)character]++;
                nonZeroCharCount++;
            }
        }

        public void WriteCharacterAndCount()
        {
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    double percentage = (counts[i]/ (double)nonZeroCharCount) *100;
                    Console.WriteLine($"{(char)i} - {counts[i]} - {percentage:F2}%");
                }
            }
        }
    }
}
