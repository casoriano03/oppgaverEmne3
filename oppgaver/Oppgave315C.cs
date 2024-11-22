using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppgaver
{
    internal class Oppgave315C : IOppgaver

    {
    public void Run()
    {
        reverseString();
    }

    static void reverseString()
    {
        Console.WriteLine("Enter a word or named to be reversed");
        var inputStr = Console.ReadLine();
        var reversedStr = "";

        for (var i = inputStr.Length - 1; i >= 0; i--)
        {
            reversedStr += inputStr.Substring(i, 1);
        }

        Console.WriteLine($"Reversed word is: {reversedStr}");
    }
    }
}
