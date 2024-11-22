using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppgaver
{
    internal class Oppgave315G: IOppgaver
    {
        public void Run()
        {
            CharacterCounter();
        }

        public void CharacterCounter()
        {
            var range = 250;
            var counts = new int[range];
            string text = "something";
            int count = 0;
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine().ToLower();
                foreach (var character in text)
                {
                    counts[(int)character]++;
                    count++;
                }
                for (var i = 0; i < range; i++)
                {
                    if (counts[i] > 0)
                    {
                        var character = (char)i;
                        double pecentage = (counts[i] / (double) count)*100;
                        Console.WriteLine($@"{character}-{counts[i]}-{pecentage:F2}%");
                    }
                }
            }
        }
    }
}
