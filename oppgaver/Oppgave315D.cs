using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace oppgaver
{
    internal class Oppgave315D: IOppgaver
    {
        private int wordCount = 0;
        private string longestWord = "";
        private int longestWordLength = 0;
        private string wordMostVowels = "";
        private int wordMostVowelsCount = 0;
        public void Run()
        {
            WordCounter();
        }

        public void WordCounter()
        {
            Console.WriteLine("Enter sentence or paragraph: ");
            var text = Console.ReadLine();
            
            var wordsArray = text.Split();
            wordCount = wordsArray.Length;

            FindLongestWord(wordsArray);
            FindWordMostVowel(wordsArray);

            Console.WriteLine($"The text you entered has {wordCount} words");
            Console.WriteLine($"The longest word is {longestWord} with {longestWordLength} characters.");
            Console.WriteLine($"The word with most vowels is {wordMostVowels} with {wordMostVowelsCount} vowels.");
        }

        public void FindLongestWord(string [] array )
        {
            foreach (var word in array)
            {
                if (word.Length <= longestWordLength) continue;
                longestWordLength = word.Length;
                longestWord = word;
            }
        }

        public void FindWordMostVowel(string[] array)
        {
            foreach (var word in array)
            {
                var wordVowelCount = word.Where((t, i) => word.Substring(i, 1) == "a" || word.Substring(i, 1) == "e" || word.Substring(i, 1) == "i" || word.Substring(i, 1) == "o" || word.Substring(i, 1) == "u").Count();

                if (wordVowelCount <= wordMostVowelsCount) continue;
                wordMostVowelsCount = wordVowelCount;
                wordMostVowels = word;
            }
        }

    }
}
